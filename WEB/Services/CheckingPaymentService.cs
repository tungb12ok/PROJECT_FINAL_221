using Newtonsoft.Json;
namespace WEB.Services
{
    public class CheckingPaymentService
    {
        public async Task<bool> checkingPayment()
        {
            CheckingPayment p = new CheckingPayment();
            var jsonData = "";
            jsonData = await p.ExeServiceAsync();
            var jsonDataObj = JsonConvert.DeserializeObject<TransactionInfo>(jsonData);

            // Tìm kiếm theo các điều kiện
            //var result = jsonDataObj.Find(item =>
            //    item.id == userID &&
            //    item.description.Contains(description) &&
            //    item.arrangementId.Contains(transactionID));

            // Kiểm tra xem có dữ liệu nào khớp không
            //if (result != null)
            //{
            //    // Trả về kết quả dưới dạng JSON hoặc thông tin cần thiết
            //    return JsonConvert.SerializeObject(result);
            //}
            //else
            //{
            //    // Trả về một giá trị mặc định hoặc null nếu không tìm thấy
            //    return "Không tìm thấy dữ liệu phù hợp.";
            //}
            return false;
        }
    }
}
