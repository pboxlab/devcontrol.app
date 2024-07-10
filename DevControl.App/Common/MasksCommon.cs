using System.Text.RegularExpressions;

namespace DevControl.App.Common
{
    public static class MasksCommon
    {
        public static void OnlyNumberKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        public static string ConvertSshToHttp(string gitUrl)
        {
            if (gitUrl == null) return "";

            // Regex para verificar e capturar partes de um URL SSH de repositório GIT
            string sshPattern = @"git@(.*):(.*)/(.*).git";
            Regex sshRegex = new Regex(sshPattern);

            if (sshRegex.IsMatch(gitUrl))
            {
                var match = sshRegex.Match(gitUrl);
                string domain = match.Groups[1].Value;
                string user = match.Groups[2].Value;
                string repository = match.Groups[3].Value;

                // Monta a URL HTTP correspondente
                return $"https://{domain}/{user}/{repository}";
            }

            // Se não for um URL SSH, retorna o URL original
            return gitUrl;
        }
    }
}
