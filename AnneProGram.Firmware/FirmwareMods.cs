namespace AnneProGram.Firmware
{
	public static class FirmwareMods
	{
		public static readonly FirmwareMod[] Values = new[]
		{
			new FirmwareMod("CtrlCtrl-FnCtrl", ByteReplacement.For(0X42F20101, 0X40F20141)), // Switch Layout. Ctrl+Ctrl > Fn+Ctrl
			new FirmwareMod("FnR-FnQ", ByteReplacement.For(0XBAF1120F, 0XBAF10F0F)), // RGB. 0x12 (18) > 0x0F (15)
			new FirmwareMod("FnT-FnZ", ByteReplacement.For(0XBAF1130F, 0XBAF12B0F)), // RAT. 0x13 (19) > 0x2B (43)
			new FirmwareMod("FnY-FnX", ByteReplacement.For(0XBAF1140F, 0XBAF12C0F)), // BRT. 0x14 (20) > 0x2C (44)
			new FirmwareMod("FnU-FnC", ByteReplacement.For(0XBAF1150F, 0XBAF12D0F)), // MOD. 0x15 (21) > 0x2D (45)
			new FirmwareMod("FnB-FnE", ByteReplacement.For(0XBAF12F0F, 0XBAF1110F), ByteReplacement.For(0X2F21, 0X1121), ByteReplacement.For(0X2F23, 0X1123)), // Bluetooth. 0x2F (47) > 0x11 (17)
		};
	}
}
