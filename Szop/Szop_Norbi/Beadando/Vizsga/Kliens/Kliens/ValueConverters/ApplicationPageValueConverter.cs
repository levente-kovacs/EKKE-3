using Kliens.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Kliens
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();
                case ApplicationPage.Home:
                    return new HomePage();
                case ApplicationPage.Add:
                    return new AddPage();
                case ApplicationPage.Upd:
                    return new UpdPage();
                case ApplicationPage.Del:
                    return new DelPage();
                case ApplicationPage.Fuel:
                    return new FuelPage();
                case ApplicationPage.Doc:
                    return new DocPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
