namespace BusinessObject
{
    public class CustomerObject
    {
        public bool ValidateString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public bool ValidateRole(string input, out int role)
        {
            return int.TryParse(input, out role);
        }
    }
}
