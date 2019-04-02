namespace Dwapi.Hts.SharedKernel.Model
{
    public class VerificationResponse
    {
        public string RegistryName { get; set; }
        public bool Verified { get; set; }

        public VerificationResponse(string registryName, bool verified)
        {
            RegistryName = registryName;
            Verified = verified;
        }
    }
}