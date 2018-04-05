using System.ComponentModel.DataAnnotations.Schema;
using Nest;

namespace Valeriy.Domain.Entities
{
    [Table("products")]
    public class Product
    {
        [Column("class_id")]
        public string ClassId { get; set; }

        [Column("product_id")]
        public string ProductId { get; set; }

        [Column("sku_number")]
        public string SkuNumber { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("product_url")]
        public string ProductUrl { get; set; }

        [Column("buy_url")]
        public string BuyUrl { get; set; }

        [Column("product_image_url")]
        public string ProductImageUrl { get; set; }

        [Column("short_product_description")]
        public string ShortProductDescription { get; set; }

        [Column("long_product_description")]
        public string LongProductDescription { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("age")]
        public string Age { get; set; }

        [Column("material")]
        public string Material { get; set; }

        [Column("style")]
        public string Style { get; set; }

        [Column("cools_colors")]
        public string CoolsColors { get; set; }

        [Column("cools_sizes")]
        public string CoolsSizes { get; set; }

        [Column("availability")]
        public string Availability { get; set; }

        [Column("begin_date")]
        public string BeginDate { get; set; }

        [Column("end_date")]
        public string EndDate { get; set; }

        [Column("sale_price")]
        public double RetailPrice { get; set; }

        [Column("currency")]
        public string SalePrice { get; set; }

        [Column("discount_type")]
        public string Currency { get; set; }

        [Column("discount")]
        public string DiscountType { get; set; }

        [Column("shipping")]
        public string Discount { get; set; }

        [Column("shipping_information")]
        public string Shipping { get; set; }

        [Column("manufacture_part_number")]
        public string ShippingInformation { get; set; }

        [Column("manufacture_name")]
        public string ManufacturePartNumber { get; set; }

        [Column("brand")]
        public string ManufactureName { get; set; }

        [Column("keywords")]
        public string Brand { get; set; }

        [Column("cools_primary_department")]
        public string Keywords { get; set; }

        [Column("cools_primary_category")]
        public string CoolsPrimaryDepartment { get; set; }

        [Column("cools_secondary_category")]
        public string CoolsPrimaryCategory { get; set; }

        [Column("cools_sub_category")]
        public string CoolsSecondaryCategory { get; set; }

        [Column("is_new")]
        public string CoolsSubCategory { get; set; }

        [Column("retail_price")]
        public string IsNew { get; set; }
    }
}