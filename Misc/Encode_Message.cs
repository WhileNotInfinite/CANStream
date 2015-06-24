ByteMessageData = new byte[MsgByteLength];
long CurrentMuxVal = GetCurrentMultiplexerValue();

foreach(CANParameter oParam in Parameters)
{
	if ((!oParam.IsMultiplexed) ||(oParam.IsMultiplexed && oParam.MultiplexerValue == CurrentMuxVal))
	{
		//Get paramter value into an array of bytes, most significant byte being byte 0
		// 4258 = 0x10A2 => Byte[0] = 0x10, Byte[1] = 0xA2
		byte[] ParamBytes = GetParameterBytes(oParam);
		
		int iMapByte = oParam.StartBit / 8;
		int iBitInMapByte = oParam.StartBit - iMapByte * 8;
		
		int Rem = 0;
		Math.DivRem(oParam.Length, 8, out Rem);
		
		switch (oParam.Endianess)
		{
			case CanParameterEndianess.MSBFirst: //Most significant bytes first
											
				for (int iByte = 0; iByte < ParamBytes.Length; iByte++) //For each byte of the parameter: From the most (0) to the least (0...7) significant
				{
					int iBitStart = 7;
					if (iByte == 0 && Rem != 0) iBitStart = Rem - 1; //If parameter lenght isn't dividable by 8, fisrt byte isn't full (13 bits => Byte[0]: 5 bits / Byte[1]: 8 bits)
					
					for (int iBit = iBitStart; iBit >= 0; iBit--) //For each used bit of the current byte
					{
						int BitVal = (ParamBytes[iByte] & (1 << iBit)) >> iBit; //Get the value (0 or 1) of the current bit of the current parameter byte
						byte MapBitVal = (byte)(BitVal << iBitInMapByte); //Set the bit value retrieved into the message byte
						
						ByteMessageData[iMapByte] += MapBitVal; //Update message map byte
						
						iBitInMapByte--; //Next MSB parameter bit into the message map
						if (iBitInMapByte < 0)
						{
							iMapByte++;
							iBitInMapByte = 7;
						}
					}
				}
				
				break;
				
			case CanParameterEndianess.LSBFirst: //Least significant bytes first
				
				for (int iByte = ParamBytes.Length - 1; iByte >= 0; iByte--) //For each byte of the parameter: From the least (0...7) to the most (0) significant
				{
					int iBitEnd = 8;
					if (iByte == 0 && Rem != 0) iBitEnd = Rem; //If parameter lenght isn't dividable by 8, fisrt byte isn't full (13 bits => Byte[0]: 5 bits / Byte[1]: 8 bits)
					
					for (int iBit = 0; iBit < iBitEnd; iBit++) //For each used bit of the current byte
					{
						int BitVal = (ParamBytes[iByte] & (1 << iBit)) >> iBit; //Get the value (0 or 1) of the current bit of the current parameter byte
						byte MapBitVal = (byte)(BitVal << iBitInMapByte); //Set the bit value retrieved into the message byte
						
						ByteMessageData[iMapByte] += MapBitVal; //Update message map byte
						
						iBitInMapByte++; //Next LSB parameter bit into the message map
						if (iBitInMapByte > 7)
						{
							iMapByte++;
							iBitInMapByte = 0;
						}
					}	
				}
				
				break;
		}
	}
}