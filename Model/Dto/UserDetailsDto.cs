namespace Model.Dto
{
    public class UserDetailsDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string ContactNo { get; set; }
        public IList<string> Roles { get; set; }
    }

}
