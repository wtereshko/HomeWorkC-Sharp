using System;
using NUnit.Framework;

namespace WebServiceTest
{
   [TestFixture]
   public class ItemTests: BaseTestClass
    {
        private string actualResponse;
        private string addedItems = String.Empty;
        
        //http://localhost:8080/item/{index}?token= &item= &index =&reqtype=addItem 
        [TestCase("Square", "1")]
        [TestCase("Circle", "2")]
        public void TestAddItem(string itemName, string index)
        {
            addedItems += string.Format(index + " " + "\t" + itemName + "\n");
            actualResponse = ServiceHelper.PostRequest(ServiceHelper.item, Token, itemName, index);
            Log($"Test Add Item: result = {actualResponse}");
            Assert.AreEqual("true", actualResponse);
        }

        //http://localhost:8080/items?token= &reqtype=getAllItems  
        [Test]
        public void TestGetAllItems()
        {
            actualResponse = ServiceHelper.GetRequest(ServiceHelper.items, Token);
            Log($"Test Get All Items: result = {actualResponse}");
            Assert.AreEqual(addedItems, actualResponse);
        }

        //http://localhost:8080/item/{index}?token= &index= &reqtype=deleteItem
        [TestCase("Book", "3")]
        public void TestRemoveItem(string itemName, string itemIndex)
        {
            string addItemResult = ServiceHelper.PostRequest(ServiceHelper.item, Token, itemName, itemIndex);
            string removeItemResult = ServiceHelper.DeleteRequest(ServiceHelper.item, Token, itemIndex);
            actualResponse = ServiceHelper.GetRequest(ServiceHelper.items, Token);

            Log("Test Remove Item:" + "\n" + $"result add item = {addItemResult} " + "\n" +
                $"result remove item = {removeItemResult}" + "\n" +
                $"items in data base = {actualResponse}");

            StringAssert.DoesNotContain(itemName, actualResponse);
        }
    }
}
