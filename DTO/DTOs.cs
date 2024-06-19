namespace Project2.DTOs
{
    public class FoodDTO
    {
        public int FoodId { get; set; }
        public string? ItemName { get; set; }
        public decimal Price { get; set; }
        public int FoodQuantity { get; set; }
        public bool InStock { get; set; }

    }

    public class PurchaseDTO
    {
        public int PurchaseId { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public int PurchaseQuantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string? UserType { get; set; }
    }

    public class UserDTO
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }

    public class UserLoginDTO
        {
            public string? UserName {get;set;}
            public  string? Password {get;set;}
        }

    public class LoginResponseDTO
        {
            public string? UserName {get;set;}
            public string? Authorization {get;set;}
        }
}