namespace DeskMarket.Data.Constants
{
	public static class ValidationConstants
	{
		// Product
		public const int PRODUCT_NAME_MIN_LENGTH = 2;
		public const int PRODUCT_NAME_MAX_LENGTH = 60;
		public const int DESCRIPTION_MIN_LENGTH = 10;
		public const int DESCRIPTION_MAX_LENGTH = 250;
		public const decimal PRICE_MIN_LENGTH = 1.00m;
		public const decimal PRICE_MAX_LENGTH = 3000.00m;

		// Category
		public const int CATEGORY_NAME_MIN_LENGTH = 3;
		public const int CATEGORY_NAME_MAX_LENGTH = 20;
	}
}
