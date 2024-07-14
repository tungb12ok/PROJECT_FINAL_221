namespace WEB.Extenstions
{
    public class Helper
    {
        public static string GenerateOTP()
        {
            // Tạo mã OTP ngẫu nhiên (ví dụ: một chuỗi 6 chữ số)
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // Mã OTP gồm 6 chữ số
        }

        public static string roomConnect(string sender, string receiver)
        {
            if (sender.CompareTo(receiver) < 0)
            {
                return sender + "-" + receiver;
            }
            else
            {
                return receiver + "-" + sender;
            }
        }
    }
}