#include "AD7606.h"


//uint16_t AD7606_readFirstData(void);


void AD7606_config(void)
{        
    AD7606_RANGE_5V();
    AD7606_CS_HIGH();
    AD7606_RST_LOW();
    AD7606_RD_HIGH();
    AD7606_CONVA_HIGH();
		AD7606_CONVB_HIGH();

    AD7606_SampleRate(AD7606_SAMPLE_200K);
}


void AD7606_SampleRate(uint8_t sampleRate)
{
    switch (sampleRate)
    {
    case AD7606_SAMPLE_200K:	//200kHz
        AD7606_OS0_LOW();
        AD7606_OS1_LOW();
        AD7606_OS2_LOW();
        break;

    case AD7606_SAMPLE_100K:	//100kHz
        AD7606_OS0_HIGH();
        AD7606_OS1_LOW();
        AD7606_OS2_LOW();
        break;

    case AD7606_SAMPLE_50K:	//50kHz
        AD7606_OS0_LOW();
        AD7606_OS1_HIGH();
        AD7606_OS2_LOW();
        break;

    case AD7606_SAMPLE_25K:	//25kHz
        AD7606_OS0_HIGH();
        AD7606_OS1_HIGH();
        AD7606_OS2_LOW();
        break;

    case AD7606_SAMPLE_12K5:	//12.5kHz
        AD7606_OS0_LOW();
        AD7606_OS1_LOW();
        AD7606_OS2_HIGH();
        break;

    case AD7606_SAMPLE_6K25:	//6.25kHz
        AD7606_OS0_HIGH();
        AD7606_OS1_LOW();
        AD7606_OS2_HIGH();
        break;

    case AD7606_SAMPLE_3K125:	//3.125kHz
        AD7606_OS0_LOW();
        AD7606_OS1_HIGH();
        AD7606_OS2_HIGH();
        break;

    default:
        AD7606_OS0_LOW();	//200kHz
        AD7606_OS1_LOW();
        AD7606_OS2_LOW();
        break;
    }
}
uint8_t AD7606_readConversionValue(uint16_t *data)
{
	  
    uint8_t i;
    uint16_t counter;
    static uint8_t a = 1;
	
    AD7606_CS_RD_HIGH();   //CS\RD
    if (a == 1)
    {
        a = 0;
        AD7606_reset();     
    }
    i = AD7606_BUSY_STATE();    //BUSY

    AD7606_startConv();    

    counter = 0;
    i = AD7606_BUSY_STATE();   //BUSY
    while (i)
    {
        i = AD7606_BUSY_STATE();   //BUSY
        DWT_Delay_us(0);
        counter++;
        if (counter > 50000)    
            return 1;
    }

    AD7606_CS_LOW();    //CS

    i = AD7606_FRST_STATE();    //FRST
    AD7606_RD_HIGH();     //RD
    DWT_Delay_us(1);
    AD7606_RD_LOW();

    DWT_Delay_us(2);

    counter = 0;
    i = AD7606_FRST_STATE();    //FRST
    while (!i)
    {
        //DWT_Delay_us(1);
        i = AD7606_FRST_STATE();     //FRST
        counter++;
        if (counter > 50000)   
            return 2;
    }

    data[0] = AD7606_ReadData();     

    AD7606_RD_HIGH();      //---------AD7606_RD_HIGH

    for (i = 1; i <= 7; i++)
    {
        DWT_Delay_us(2);
        AD7606_RD_LOW();    //RD

        DWT_Delay_us(1);
			  data[i] = AD7606_ReadData();
			
        //data[i] = AD7606_READ_DATA();   
        //data[i] = ((data[i] & 0xff) << 8) + (data[i] >> 8);

        DWT_Delay_us(2);
        AD7606_RD_HIGH();    
    }

    AD7606_CS_HIGH();
    AD7606_CONVA_HIGH();
    AD7606_CONVB_HIGH();	
    return 0;
}


/*uint8_t AD7606_readConversionValue(uint16_t *data)
{
	  
    uint8_t i;
    uint16_t counter;
    static uint8_t a = 1;
	
    AD7606_CS_RD_HIGH();   //CS\RD
    if (a == 1)
    {
        a = 0;
        AD7606_reset();     
    }
    i = AD7606_BUSY_STATE();    //BUSY

    AD7606_startConv();    

    counter = 0;
    i = AD7606_BUSY_STATE();   //BUSY
    while (i)
    {
        i = AD7606_BUSY_STATE();   //BUSY
        DWT_Delay_us(0);
        counter++;
        if (counter > 50000)    
            return 1;
    }

    AD7606_CS_RD_LOW();    //CS     

    //DWT_Delay_us(2);

    counter = 0;
    i = AD7606_FRST_STATE();    //FRST
    while (!i)
    {        
        i = AD7606_FRST_STATE();     //FRST
        counter++;
        if (counter > 50000)   
            return 2;
    }

    data[0] = AD7606_ReadData();     

    AD7606_CS_RD_HIGH();     //---------AD7606_RD_HIGH

    for (i = 1; i <= 7; i++)
    {
        DWT_Delay_us(1);
        AD7606_CS_RD_LOW();    //RD

        DWT_Delay_us(1);
			  data[i] = AD7606_ReadData();
			
        //data[i] = AD7606_READ_DATA();   
        //data[i] = ((data[i] & 0xff) << 8) + (data[i] >> 8);

        DWT_Delay_us(1);
        AD7606_CS_RD_HIGH();   
    }		
    AD7606_CS_RD_HIGH();     
    AD7606_CONVA_HIGH();
    AD7606_CONVB_HIGH();	
    return 0;
}*/


uint16_t AD7606_ReadData(void)
{
	  uint16_t data=0;
	
	  data = HAL_GPIO_ReadPin(GPIOC,GPIO_PIN_4)  |
           (HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_9) << 1) |
           (HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_8) << 2) |
           (HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_7) << 3) |
           (HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_6) << 4) |
           (HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_5) << 5) |
           (HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_4) << 6) |
           (HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_3) << 7) |
           (HAL_GPIO_ReadPin(GPIOD,GPIO_PIN_2) << 8) |
           (HAL_GPIO_ReadPin(GPIOC,GPIO_PIN_11) << 9) |
           (HAL_GPIO_ReadPin(GPIOC,GPIO_PIN_10) << 10) |
           (HAL_GPIO_ReadPin(GPIOC,GPIO_PIN_7) << 11) |
           (HAL_GPIO_ReadPin(GPIOC,GPIO_PIN_8) << 12) |
           (HAL_GPIO_ReadPin(GPIOC,GPIO_PIN_9) << 13) |
           (HAL_GPIO_ReadPin(GPIOA,GPIO_PIN_8) << 14) |
           (HAL_GPIO_ReadPin(GPIOA,GPIO_PIN_9) << 15);
	  return data;
}

void AD7606_reset(void)
{
    AD7606_RST_HIGH();
    DWT_Delay_us(1);
    AD7606_RST_LOW();
    DWT_Delay_us(1);
}

void AD7606_startConv(void)
{
    AD7606_CONVA_HIGH();
	  DWT_Delay_us(1);
	  AD7606_CONVA_LOW();
	  DWT_Delay_us(1);
	  AD7606_CONVA_HIGH();	  
    AD7606_CONVB_HIGH();
	  DWT_Delay_us(1);
    AD7606_CONVB_LOW();	
	  DWT_Delay_us(1);
	  AD7606_CONVB_HIGH();  
    DWT_Delay_us(1);
}


