namespace BookAndOrder.Interfaces
{
    public interface IOrderService
    {
        Task<int> PlaceOrderAsync(string? userId = null);
    }
}
