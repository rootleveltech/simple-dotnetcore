using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public static class ShoppingList
    {
        public static IEnumerable<ShoppingListItem> GetAllItems()
        {
            using (var db = new LiteDatabase(@"ShoppingList.db"))
            {
                var shoppingListItems = db.GetCollection<ShoppingListItem>("shoppingListItems");
                shoppingListItems.EnsureIndex(x => x.ItemName);

                return shoppingListItems.FindAll().ToList();
            }
        }

        public static ShoppingListItem GetItemById(int id)
        {
            using (var db = new LiteDatabase(@"ShoppingList.db"))
            {
                var shoppingListItems = db.GetCollection<ShoppingListItem>("shoppingListItems");
                return shoppingListItems.FindById(id);
            }
        }

        public static void AddNewItem(ShoppingListItem shoppingListItem)
        {
            using (var db = new LiteDatabase(@"ShoppingList.db"))
            {
                var shoppingListItems = db.GetCollection<ShoppingListItem>("shoppingListItems");
                shoppingListItems.Insert(shoppingListItem);
                shoppingListItems.EnsureIndex(x => x.ItemName);
            }
        }

        public static void UpdateItem(ShoppingListItem shoppingListItem)
        {
            using (var db = new LiteDatabase(@"ShoppingList.db"))
            {
                var shoppingListItems = db.GetCollection<ShoppingListItem>("shoppingListItems");
                shoppingListItems.Update(shoppingListItem);
                shoppingListItems.EnsureIndex(x => x.ItemName);
            }
        }

        public static void DeleteItem(int id)
        {
            using (var db = new LiteDatabase(@"ShoppingList.db"))
            {
                var shoppingListItems = db.GetCollection<ShoppingListItem>("shoppingListItems");
                shoppingListItems.Delete(id);
            }
        }
    }
}
