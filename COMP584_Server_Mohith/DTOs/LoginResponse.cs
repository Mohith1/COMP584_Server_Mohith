namespace COMP584_Server_Mohith.DTOs
{
    public class LoginResponse
    {
        public required bool Success { get; set; }
        public required string Message { get; set; }

        public required string Token { get; set; }
    }
}
