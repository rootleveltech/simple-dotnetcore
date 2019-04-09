using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        /// <summary>
        /// Get all items in the shopping list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ShoppingListItem> Get()
        {
            return Services.ShoppingList.GetAllItems();
        }

        /// <summary>
        /// Get shopping list item by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ShoppingListItem Get(int id)
        {
            return Services.ShoppingList.GetItemById(id);
        }

        /// <summary>
        /// Add item to the shopping list
        /// </summary>
        [HttpPost]
        public void Post([FromBody] ShoppingListItem shoppingListItem)
        {
            Services.ShoppingList.AddNewItem(shoppingListItem);
        }

        /// <summary>
        /// Update a shopping item
        /// </summary>
        [HttpPut]
        public void Put([FromBody] ShoppingListItem shoppingListItem)
        {
            Services.ShoppingList.UpdateItem(shoppingListItem);
        }

        /// <summary>
        /// Delete item from list
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Services.ShoppingList.DeleteItem(id);
        }
    }
}
