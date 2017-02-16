using System;

namespace Modulo2TipCalc.Services
{
    public static class TipInfoService
    {
        public static decimal CalculateTotal(decimal Total, decimal TipValue)
        {
            return Total + TipValue;
        }

        public static decimal CalculateTip(decimal Total, decimal Subtotal, decimal TipPercent)
        {
            if (Total == 0m || Subtotal == 0m || TipPercent == 0m)
                return 0m;

            var percent = TipPercent;
            percent /= 100;
            decimal value = (Subtotal * (1 + percent)) + (Total - Subtotal);
            decimal fract = value - Math.Truncate(value);
            int f = (int)(fract * 100);
            while ((f % 25) != 0)
                ++f;
            fract = f;
            fract /= 100;
            value = Math.Truncate(value) + fract;

            return value - Total;
        }
    }
}
