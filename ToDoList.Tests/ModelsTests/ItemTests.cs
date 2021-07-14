using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTests : IDisposable
  {
    public void Dispose()
    {
      Item.ClearAll();
    }

    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      Item newItem = new Item("test");
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      Assert.AreEqual(description, newItem.Description);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      string updatedDescription = "Do the dishes";
      newItem.Description = updatedDescription;

      Assert.AreEqual(updatedDescription, newItem.Description);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      List<Item> newList = new List<Item> {};
      CollectionAssert.AreEqual(newList, Item.GetAll());
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      List<Item> newList = new List<Item> { 
        new Item("Walk the dog"), 
        new Item("Wash the dishes") 
      };

      List<Item> result = Item.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }
  }
}