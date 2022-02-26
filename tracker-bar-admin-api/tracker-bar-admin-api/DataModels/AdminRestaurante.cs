namespace tracker_bar_admin_api.DataModels
{
    public class AdminRestaurante
    {
        public int AdminRestauranteId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
