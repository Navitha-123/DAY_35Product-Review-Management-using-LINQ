using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAY_35Product_Review_Management_using_LINQ
{
    public class Management
    {
        public readonly Datatable datatable = new Datatable();
        private  object listproductreview;
        private object listproductReview;

        //UC2
        public void Toprecords(List<ProductReview> listprodctReview)
        {
            var recodData = (from ProductReview in listprodctReview orderby ProductReview.Rating descending select ProductReview).Take(5);
            foreach(var list in recodData)
            {
                Console.WriteLine("productid" + list.productid + "orderid" + list.orderid + "rating" + list.Rating + "Review" + list.Review + "IsLike" + list.IsLike);
            }

          

        }
        //UC3
        public void SelectRecords(List<ProductReview> listproductReview)
        {
            var recordData = from productReviews in listproductReview
                             where (productReviews.productid == 1 && productReviews.Rating > 4) || (productReviews.productid == 5 && productReviews.Rating > 4)
                             select productReviews;
            foreach(var list in recordData )
            {
                Console.WriteLine("productid" + list.productid + "orderid" + list.orderid + "rating" + list.Rating + "Review" + list.Review + "IsLike" + list.IsLike);
            }
        }
        //UC4

        public void RetriveCountOfRecords(List<ProductReview>listproductreview)
        {
            var recordData = listproductreview.GroupBy(X => X.productid).Select(x => new { productid = x.Key, count = x.Count() });
            foreach(var list in recordData)
            {
                Console.WriteLine(list.productid+""+list.count);
            }
        }
        //UC5RetriveProductidAndReview
        public void RetriveProductidAndReview(List<ProductReview> listproductreview)
        {
            var recordData = from productreviews in listproductreview select productreviews;
            foreach( var record in recordData)
            {
                Console.WriteLine("productid:"+record.productid+"Review "+ record.Review);
            }
        }

        //UC6SkipTopRecords

        public void SkipTopRecords(List<ProductReview> listproductReview)
        {
            var recordData = (from productReviews in listproductReview select productReviews).Skip(3);
            foreach(var record in recordData)
            {
                Console.WriteLine("product id"+record.productid+"orderid"+record.orderid + "reating"+record.Rating + "Review"+record.Review);

            }
        }

        //UC7
        public void RetriveonlyProductIdAndReview(List<ProductReview> listproductreview)
        {
            var recordData = from productReviews in listproductReview select productReviews;
            foreach(var list in recordData)
            {
                Console.WriteLine("productid"+list.productid+"Review"+list.Review);

            }
        }

        //UC9

        public void RetriveRecordIslikeValue(List<ProductReview> listproducteview)
        {
            var recordData = from productreviews in listproductreview where productreviews.IsLike == true select productreviews
            foreach (var list in recordData)
            {
                Console.WriteLine("productid" + list.productid + "orderid" + list.orderid + "rating" + list.Rating + "Review" + list.Review + "IsLike" + list.IsLike);
            }
            
        }

        //UC10

        public void AverageRating(List<ProductReview> listproductReview)
        {
            var recordData = listproductreview.GroupBy(X => X.productid).Select(x => new { productid = x.Key, Avg = x.Average(g=>g.Rating) });
            foreach (var list in recordData)
            {
                Console.WriteLine(list.productid+""+list.Avg);
            }
        }

        //UC12

        public void RetriveSomeRecords(List<ProductReview> listproductReview)
        {
            var recordData = from productreviews in listproductReview where (productreviews.orderid == 15) orderby productreviews.Rating select productreviews;
            foreach(var list in recordData)
            {
                Console.WriteLine("productid" + list.productid + "orderid" + list.orderid + "rating" + list.Rating + "Review" + list.Review + "IsLike" + list.IsLike);
            }
        }

    }
}
