using System.Security.Cryptography;
using System.Text;

namespace Login.Services
{
    public class Decryptor
    {
        private readonly string _key = "<RSAKeyValue><Modulus>9O/ZodAC5eG+4pRFKDLpwPCd0PMDqx5I4FTU+gq+0G9naJG61uHqSrLZYVoY2J5aOlxj73/k6mEgwkgm2e5+CQUK/PCqMohhnMNY2FwFS5B3c2e0va86UIbrFlA1QNeZGcksMb6cr4ROLlFX0Q8S8MVlm3UpVT2GIrvIO23ta8koOEmkP/4MFG7Pwd8NArrP0ExyJcxu8UFSXAygbpRZa5YfcZlWs1i5YCF9Olej4cPI0EdIYlD0gv8vwpg09SaFO2huAwW0OFuaDpbr5Hpb6PjfrmI9I4BBYAb8v9IvVMGfbCMEmgyp2S3zdj24moLIEGfb+qPU7cRFu1yZiq/B8Q==</Modulus><Exponent>AQAB</Exponent><P>/OB6fVnJ/IBYlbUfvNzMfgljBLd9lvq0dLK39GOGZ9DMuDJI+QqE7bjjCy61TYBQ23zzxh80q1pVCVpA87dLcaOOeJpoqHC7SQIPGsSbwobGxxVjJZA2lWAGGh75PASiIZPZwTS40IEvQzEAhuRjiCwAOqSycl86NWROZgb40DM=</P><Q>9/ZEk1WIOh3gLQQm6r78qnd8Hetqv7YUdRTM0EgfuGa7ErnIsQwt0cYsjpIOmfz8DAsDSr0hcsgrovMHsF5qnvWxKRroQfapW8h5jtkXhIl3KFniDBuRQQR8Y9ljhted9TxW0shgOf7euTTDcbDi+s0Lhzn0ua7ZbHFF5JtLMUs=</Q><DP>fC3kGOBZ71Q7rDDIyB8JkK8dX/iXhOfSbChDa5DgNOT1U1LmQN3ojzCm1hv2zns/ubkvoNA8NhVjAve+Q7B0LPbrhNAWqvjJD74iGrwH3UwAG02mZZDfLRV9iaBCNjX0RFbtrRIt275ErlNG9fb75aft6N5t/vpChGugkDvGPb8=</DP><DQ>vhe75r+RmgxBSgF+3EPia8UCD+XkhmhOMpvpkFtahgGrtOVcp+5QShuFGR97ti2uBIWE1o070UUHvvpVkK4xSv/L+1k3aSpyF30PQ6XGU8MW6IZPtzyDFLcdrWaA2GUAIXtKjHk03AE6Of3rP4N93wvGpLqXlKoo4OvNyz4KXRU=</DQ><InverseQ>283xlqy1tmG//MuYlW1wFDguweqWF/XmTn+8YgkOsJqde68oNAQuXxOHvEtfi4HuZH94DEVOkZ4jxZ/DFNx3cD8thYQdXwl42BLen4tirtN7OFtOa6DsJDsbu3w4l5eIyZ3X3wV7P4/PuQcFp5AHlQF701G9P5/vCmFKbFNR/OU=</InverseQ><D>0bkpPJ7yTEmd+z3/dSsa8YRVbNsXsgZNWh/o+GwI9EnfXi8hrupjhTBcZzoQ+jGkikIfo6t7o6Akv5WuBn5p1mlF/kxHPtt90Q+G3EL2mbwKO3t5y8zk/px3YHSvFGVGh0i0madfW/3KP2iQ68Wfbx9mH9US3hS+7LCjAxfd6aH4AbX5Ii+vp/ch89EhSiLyIlUzdpy9kz5GNZ+acO8vdb4rauY/yyVmrut1Pd1cuxz7SsK8t/CObLMG9oR5RIhypYKPZJ2/DDjYyzv2TcoatHRkT3YcIpd6qv/I2hpWFVy8TuMov4ruTw7KqoXE//aaJiVLidkt89K4k4CO5/2THQ==</D></RSAKeyValue>";
        public string Decrypt(string data)
        {
            RSA rsa = RSA.Create();
            rsa.FromXmlString(_key);
            byte[] decryption = rsa.Decrypt(Convert.FromBase64String(data), RSAEncryptionPadding.OaepSHA256);
            string result = Encoding.UTF8.GetString(decryption);
            return result;
        }
    }
}
