using Project2.Data;
using Project2.DTOs;
using Project2.Models;

namespace Project2.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext _context;

        // Constructor to inject the database context
        public PurchaseService(AppDbContext context)
        {
            _context = context;
        }

        // Method to create a new Purchase based on the provided PurchaseDTO
        public Purchase CreatePurchase(PurchaseDTO PurchaseDto)
        {
            if (ValidateNewPurchase(PurchaseDto))
            {
                var Purchase = new Purchase
                {
                    UserId = PurchaseDto.UserId,
                    FoodId = PurchaseDto.FoodId,
                    PurchaseQuantity = PurchaseDto.PurchaseQuantity,
                    Cost = PurchaseDto.Cost,
                    PurchaseDate = PurchaseDto.PurchaseDate

                };

                _context.Purchases.Add(Purchase);
                _context.SaveChanges();

                return Purchase;
            }
            else
            {
                throw new Exception("Invalid Purchase");
            }
        }

        // Private method to validate the new Purchase data
        private bool ValidateNewPurchase(PurchaseDTO PurchaseDto)
        {
            return !string.IsNullOrWhiteSpace(PurchaseDto.UserId.ToString());
        }

        // Method to delete a Purchase based on their ID
        public void DeletePurchase(int PurchaseId)
        {
            var Purchase = _context.Purchases.FirstOrDefault(f => f.PurchaseId == PurchaseId);

            if (Purchase != null)
            {
                _context.Purchases.Remove(Purchase);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Purchase not found");
            }
        }

        // Method to get a list of all purchases
        public IEnumerable<PurchaseDTO> GetAllPurchases()
        {
            var purchases = _context.Purchases
                .Select(p => new PurchaseDTO
                {
                    PurchaseId = p.PurchaseId,
                    UserId = p.UserId,
                    FoodId = p.FoodId,
                    PurchaseQuantity = p.PurchaseQuantity,
                    Cost = p.Cost,
                    PurchaseDate = p.PurchaseDate

                }).ToList();

            return purchases;
        }

        // Method to get a specific Purchase by their ID
        public PurchaseDTO GetPurchaseById(int PurchaseId)
        {
            var Purchase = _context.Purchases.Find(PurchaseId);

            if (Purchase != null)
            {
                var purchaseDto = new PurchaseDTO
                {
                    PurchaseId = Purchase.PurchaseId,
                    UserId = Purchase.UserId,
                    FoodId = Purchase.FoodId,
                    PurchaseQuantity = Purchase.PurchaseQuantity,
                    Cost = Purchase.Cost,
                    PurchaseDate = Purchase.PurchaseDate
                          
                    
                };

                return purchaseDto;
            }
            else
            {
                throw new Exception("Purchase not found");
            }
        }

        // Method to update an existing Purchase based on their ID and the provided updated PurchaseDTO
        public void UpdatedPurchase(int PurchaseId, PurchaseDTO UpdatedPurchase)
        {
            var purchase = _context.Purchases.FirstOrDefault(u => u.PurchaseId == PurchaseId);

            if (purchase != null)
            {
                purchase.UserId = UpdatedPurchase.UserId;
                purchase.FoodId = UpdatedPurchase.FoodId;
                purchase.PurchaseQuantity = UpdatedPurchase.PurchaseQuantity;
                purchase.Cost = UpdatedPurchase.Cost;

                _context.Purchases.Update(purchase);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Purchase not found");
            }
        }

    }

}