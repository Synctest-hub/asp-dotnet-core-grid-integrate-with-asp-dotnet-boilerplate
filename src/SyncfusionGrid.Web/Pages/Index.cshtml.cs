using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using Syncfusion.EJ2.Base;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace SyncfusionGrid.Web.Pages;

public class IndexModel : SyncfusionGridPageModel
{
    public static List<OrdersDetails> orddata = OrdersDetails.GetAllRecords();
    public void OnGet()
    {

    }

    // all data operation except crud post.

    public JsonResult OnPostGridDataOperationHandler([FromBody] DataManagerRequest dm)
    {
        IEnumerable DataSource = orddata.ToList();
        DataOperations operation = new DataOperations();

        if (dm.Search != null && dm.Search.Count > 0)
        {
            DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
        }
        if (dm.Where != null && dm.Where.Count > 0) //Filtering
        {
            DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
        }
        if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
        {
            DataSource = operation.PerformSorting(DataSource, dm.Sorted);
        }
        int count = DataSource.Cast<OrdersDetails>().Count();
        if (dm.Skip != 0)
        {
            DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
        }
        if (dm.Take != 0)
        {
            DataSource = operation.PerformTake(DataSource, dm.Take);    //Paging
        }
        return dm.RequiresCounts ? new JsonResult(new { result = DataSource, count = count }) : new JsonResult(DataSource);
    }

    // normal edit insert post.

    public JsonResult OnPostGridInsertPostHandler([FromBody] CRUDModel<OrdersDetails> value)
    {
        orddata.Insert(0, value.Value);
        return new JsonResult(value);
    }

    // normal edit update post.

    public JsonResult OnPostGridUpdatePostHandler([FromBody] CRUDModel<OrdersDetails> value)
    {
        var data = orddata.Where(or => or.OrderID == value.Value.OrderID).FirstOrDefault();
        if (data != null)
        {
            data.OrderID = value.Value.OrderID;
            data.CustomerID = value.Value.CustomerID;
            data.Freight = value.Value.Freight;
            data.EmployeeID = value.Value.EmployeeID;
            data.ShipCity = value.Value.ShipCity;
            data.Verified = value.Value.Verified;
            data.OrderDate = value.Value.OrderDate;
            data.ShipName = value.Value.ShipName;
            data.ShipCountry = value.Value.ShipCountry;
            data.ShippedDate = value.Value.ShippedDate;
            data.ShipAddress = value.Value.ShipAddress;
        }
        return new JsonResult(value);
    }

    // normal edit delete post.

    public JsonResult OnPostGridRemovePostHandler([FromBody] CRUDModel<OrdersDetails> value)
    {
        orddata.Remove(orddata.Where(or => or.OrderID == (Int64)value.Key).FirstOrDefault());
        return new JsonResult(value);
    }

    // normal edit crud url post.

    public JsonResult OnPostGridCrudPostHandler([FromBody] CRUDModel<OrdersDetails> value)
    {
        if (value.Action == "update")
        {
            var data = orddata.Where(or => or.OrderID == value.Value.OrderID).FirstOrDefault();
            if (data != null)
            {
                data.OrderID = value.Value.OrderID;
                data.CustomerID = value.Value.CustomerID;
                data.Freight = value.Value.Freight;
                data.EmployeeID = value.Value.EmployeeID;
                data.ShipCity = value.Value.ShipCity;
                data.Verified = value.Value.Verified;
                data.OrderDate = value.Value.OrderDate;
                data.ShipName = value.Value.ShipName;
                data.ShipCountry = value.Value.ShipCountry;
                data.ShippedDate = value.Value.ShippedDate;
                data.ShipAddress = value.Value.ShipAddress;
            }
        }
        else if (value.Action == "insert")
        {
            orddata.Insert(0, value.Value);
        }
        else if (value.Action == "remove")
        {

            orddata.Remove(orddata.Where(or => or.OrderID == (Int64)value.Key).FirstOrDefault());
        }
        return new JsonResult(value);
    }

    // batch edit bulk crud url post.

    public JsonResult OnPostGridBatchCrudPostHandler([FromBody] CRUDModel<OrdersDetails> value)
    {
        if (value.Changed.Count > 0)
        {
            for (int i = 0; i < value.Changed.Count; i++)
            {
                var data = orddata.Where(or => or.OrderID == value.Changed[i].OrderID).FirstOrDefault();
                if (data != null)
                {
                    data.OrderID = value.Changed[i].OrderID;
                    data.CustomerID = value.Changed[i].CustomerID;
                    data.Freight = value.Changed[i].Freight;
                    data.EmployeeID = value.Changed[i].EmployeeID;
                    data.ShipCity = value.Changed[i].ShipCity;
                    data.Verified = value.Changed[i].Verified;
                    data.OrderDate = value.Changed[i].OrderDate;
                    data.ShipName = value.Changed[i].ShipName;
                    data.ShipCountry = value.Changed[i].ShipCountry;
                    data.ShippedDate = value.Changed[i].ShippedDate;
                    data.ShipAddress = value.Changed[i].ShipAddress;
                }
            }
        }
        if (value.Added.Count > 0)
        {
            for (var i = 0; i < value.Added.Count; i++)
            {
                orddata.Insert(i, value.Added[i]);
            }
        }
        if (value.Deleted.Count > 0)
        {
            for (var i = 0; i < value.Deleted.Count; i++)
            {
                orddata.Remove(orddata.Where(or => or.OrderID == value.Deleted[i].OrderID).FirstOrDefault());
            }
        }
        return new JsonResult(value);
    }
}

// Data Model
public class OrdersDetails
{
    public OrdersDetails()
    {

    }
    public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, DateTime ShippedDate, string ShipAddress)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.Verified = Verified;
        this.OrderDate = OrderDate;
        this.ShipName = ShipName;
        this.ShipCountry = ShipCountry;
        this.ShippedDate = ShippedDate;
        this.ShipAddress = ShipAddress;
    }
    public static List<OrdersDetails> GetAllRecords()
    {
        List<OrdersDetails> order = new List<OrdersDetails>();
        int code = 10000;
        for (int i = 1; i < 100; i++)
        {
            order.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15, 10, 40, 00), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
            order.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04, 09, 30, 00), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
            order.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30, 03, 45, 00), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"));
            order.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22, 07, 30, 00), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
            order.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18, 05, 50, 00), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
            code += 5;
        }
        return order;
    }

    public static List<OrdersDetails> GetRecords()
    {
        List<OrdersDetails> orders = new List<OrdersDetails>();
        int code = 10000;
        for (int i = 1; i < 120; i++)
        {
            orders.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15, 10, 40, 00), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16, 09, 30, 00), "Kirchgasse 6"));
            orders.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04, 09, 30, 00), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11, 03, 45, 00), "Avda. Azteca 123"));
            orders.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30, 03, 45, 00), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7, 07, 50, 00), "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"));
            orders.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22, 07, 30, 00), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30, 06, 12, 00), "Magazinweg 7"));
            orders.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18, 05, 50, 00), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3, 12, 50, 00), "1029 - 12th Ave. S."));
            code += 5;
        }
        return orders;
    }

    [Key]
    [JsonProperty("OrderID")]
    public int OrderID { get; set; }
    [JsonProperty("CustomerID")]
    public string CustomerID { get; set; }
    [JsonProperty("EmployeeID")]
    public int? EmployeeID { get; set; }
    [JsonProperty("Freight")]
    public double Freight { get; set; }
    [JsonProperty("ShipCity")]
    public string? ShipCity { get; set; }
    [JsonProperty("Verified")]
    public bool? Verified { get; set; }
    [JsonProperty("OrderDate")]
    public dynamic? OrderDate { get; set; }
    [JsonProperty("ShipName")]

    public string? ShipName { get; set; }
    [JsonProperty("ShipCountry")]

    public string? ShipCountry { get; set; }
    [JsonProperty("ShippedDate")]

    public dynamic? ShippedDate { get; set; }
    [JsonProperty("ShipAddress")]
    public string? ShipAddress { get; set; }
}