using BlazorServerApp.Data.Contract;
using Data_Sharing.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages
{
    public class FetchDataBase : ComponentBase
    {
        [Inject]
        private IStore Stores { get; set; }
        [Inject]
        private IUserService UserService { get; set; }
        public IEnumerable<Store> StoreList { get; set; }
        public IEnumerable<Item> ItemList { get; set; }
        private int selectedStore;
        public IList<Item> ItemsSelected { get; set; }
        public int SelectedStoreID { get; set; }
        public string itemID { get; set; }
        public bool isSubmit { get; private set; }
        public IList<ReportEntity> Report { get; set; } = new List<ReportEntity>();

        [Parameter]
        public string id { get; set; }
        protected override async Task<IEnumerable<Store>> OnInitializedAsync()
        {
            StoreList = await Stores.GetStores();
            StoreList.ToList().Add(new Store { Id = -1, Name = "Selected Store" });
            ItemsSelected = new List<Item>();
            return StoreList;
        }
        public void changeStatus(EventArgs e)
        {
            if (SelectedStoreID == -1)
                SelectedStoreID = 0;
        }
        public async Task<IEnumerable<Item>> storeSelection(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out selectedStore))
            {
                SelectedStoreID = selectedStore;
                ItemsSelected = new List<Item>();
                var items = StoreList.First(x => x.Id == selectedStore);
                return ItemList = items.ItemList;
            }
            return ItemsSelected;
        }
        public async void getReport()
        {
            var users = await UserService.SetUser();
            var user = users.FirstOrDefault(x => x.Id.ToString() == id);
            Report.Clear();
            if (user != null)
            {
                var orders = await Stores.GetallOrders();
                orders = orders.Where(x => x.StoreID > 0);
                foreach(var item in orders)
                {
                    var store = StoreList.Where(x=>x.Id == item.StoreID).FirstOrDefault().Name;
                    var username = users.Where(x => x.Id.ToString() == id).FirstOrDefault().Name;
                    Report.Add(new ReportEntity { StoreName = store, UserName = username, Items = item.Items });
                } 
            }
        }
        public async void addItem(EventArgs e)
        {
            isSubmit = false;
            if (!string.IsNullOrWhiteSpace(itemID) && (ItemList is not null))
            {
                var itemAdded = ItemList.FirstOrDefault(x => x.Id.ToString() == itemID);
                if (itemAdded is not null)
                {
                    ItemsSelected.Add(new Item { Name = itemAdded.Name, Price = itemAdded.Price });
                    //await JS.InvokeAsync<String>("SendMessage", new object[] { "Item added" });
                }
            }
            //return;
        }
        //[JSInvokable]
        //public static string SendMessage(string msg)
        //{
        //    return msg;
        //}
        public void submit()
        {
            isSubmit = true;
        }
        public async void FormSubmitted()
        {
            if (isSubmit && ItemsSelected.Count() > 0)
            {
                Order order = new Order() { Items = ItemsSelected.ToList(), CreatedTime = DateTime.Now, UserId = "1", StoreID = selectedStore };
                await Stores.PlaceOrder(order);
                ItemsSelected = new List<Item>();
                SelectedStoreID = -1;
                itemID = string.Empty;
            }
        }
    }
}
