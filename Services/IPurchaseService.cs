using Project2.DTOs;
using Project2.Models;

namespace Project2.Services
{
    public interface IPurchaseService
    {
        // Method to get a list of all users
        IEnumerable<PurchaseDTO> GetAllPurchases();

        // Method to get a specific user by their ID
        PurchaseDTO GetPurchaseById(int PurchaseId);

        // Method to create a new user based on the provided PurchaseDTO
        Purchase CreatePurchase(PurchaseDTO PurchaseDto);

        // Method to update an existing user based on their ID and the provided updated PurchaseDTO
        void UpdatedPurchase(int PurchaseId, PurchaseDTO UpdatedPurchase);

        // Method to delete a user based on their ID
        void DeletePurchase(int PurchaseId);
    }
}