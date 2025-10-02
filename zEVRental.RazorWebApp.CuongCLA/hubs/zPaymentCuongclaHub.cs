using Microsoft.AspNetCore.SignalR;
using zEVRental.Services.CuongCLA;

namespace zEVRental.RazorWebApp.CuongCLA.hubs
{
    public class zPaymentCuongclaHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IPaymentCuongClaService _service;

        public zPaymentCuongclaHub(IPaymentCuongClaService service)
        {
            _service = service;
        }

        public async Task HubDelete_PaymentCuongcla(string paymentId)
        {
            await Clients.All.SendAsync("Receive_DeletePaymentCuongcla", paymentId);

            await _service.DeleteAsync(int.Parse(paymentId));
        }
    }
}
