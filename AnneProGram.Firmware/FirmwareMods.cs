namespace AnneProGram.Firmware
{
	public static class FirmwareMods
	{
		public static readonly FirmwareMod[] Values = new[]
		{
			new FirmwareMod("CtrlCtrl-FnCtrl", ByteReplacement.For(0x42F2_0101, 0x40F2_0141)), // Switch Layout. Ctrl+Ctrl > Fn+Ctrl
			new FirmwareMod("FnR-FnQ", ByteReplacement.For(0xBAF1_120F, 0xBAF1_0F0F)), // RGB. 0x12 (18) > 0x0F (15)
			new FirmwareMod("FnT-FnZ", ByteReplacement.For(0xBAF1_130F, 0xBAF1_2B0F)), // RAT. 0x13 (19) > 0x2B (43)
			new FirmwareMod("FnY-FnX", ByteReplacement.For(0xBAF1_140F, 0xBAF1_2C0F)), // BRT. 0x14 (20) > 0x2C (44)
			new FirmwareMod("FnU-FnC", ByteReplacement.For(0xBAF1_150F, 0xBAF1_2D0F)), // MOD. 0x15 (21) > 0x2D (45)
			new FirmwareMod("FnB-FnE", ByteReplacement.For(0xBAF1_2F0F, 0xBAF1_110F), ByteReplacement.For(0x2F21, 0x1121), ByteReplacement.For(0x2F23, 0x1123)), // Bluetooth. 0x2F (47) > 0x11 (17)
		};
	}
}
