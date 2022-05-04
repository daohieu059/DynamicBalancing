#ifndef _AD7606_H_
#define _AD7606_H_

#include "dwt_stm32_delay.h" 
#include "stm32f1xx_hal.h"


//Port A

#define     AD7606_FRST_GPIOx   GPIOA     //FRST
#define     AD7606_FRST_PORT    GPIO_PIN_7

#define     AD7606_OS0_GPIOx    GPIOA      //OS0
#define     AD7606_OS0_PORT     GPIO_PIN_2

#define     AD7606_OS1_GPIOx    GPIOA      //OS1
#define     AD7606_OS1_PORT     GPIO_PIN_1

#define     AD7606_OS2_GPIOx    GPIOA      //OS2
#define     AD7606_OS2_PORT     GPIO_PIN_0

//Port C

#define     AD7606_BUSY_GPIOx   GPIOC     //BUSY
#define     AD7606_BUSY_PORT    GPIO_PIN_13

#define     AD7606_CS_GPIOx     GPIOC     //CS
#define     AD7606_CS_PORT      GPIO_PIN_14

#define     AD7606_RD_GPIOx     GPIOC     //RD
#define     AD7606_RD_PORT      GPIO_PIN_15

#define     AD7606_RANGE_GPIOx  GPIOC     //RANGE
#define     AD7606_RANGE_PORT   GPIO_PIN_3

#define     AD7606_CONVA_GPIOx  GPIOC        //CONVA
#define     AD7606_CONVA_PORT   GPIO_PIN_2

#define     AD7606_CONVB_GPIOx  GPIOC        //CONVB
#define     AD7606_CONVB_PORT   GPIO_PIN_1

#define     AD7606_RST_GPIOx    GPIOC      //RST
#define     AD7606_RST_PORT     GPIO_PIN_0

#define     AD7606_CS_HIGH()        HAL_GPIO_WritePin(AD7606_CS_GPIOx,AD7606_CS_PORT,GPIO_PIN_SET)    
#define     AD7606_CS_LOW()         HAL_GPIO_WritePin(AD7606_CS_GPIOx,AD7606_CS_PORT,GPIO_PIN_RESET)   

#define     AD7606_RST_HIGH()       HAL_GPIO_WritePin(AD7606_RST_GPIOx,AD7606_RST_PORT,GPIO_PIN_SET)    
#define     AD7606_RST_LOW()        HAL_GPIO_WritePin(AD7606_RST_GPIOx,AD7606_RST_PORT,GPIO_PIN_RESET)   

#define     AD7606_RD_HIGH()        HAL_GPIO_WritePin(AD7606_RD_GPIOx,AD7606_RD_PORT,GPIO_PIN_SET)
#define     AD7606_RD_LOW()         HAL_GPIO_WritePin(AD7606_RD_GPIOx,AD7606_RD_PORT,GPIO_PIN_RESET)

#define     AD7606_RANGE_10V()      HAL_GPIO_WritePin(AD7606_RANGE_GPIOx,AD7606_RANGE_PORT,GPIO_PIN_SET)    //10V
#define     AD7606_RANGE_5V()       HAL_GPIO_WritePin(AD7606_RANGE_GPIOx,AD7606_RANGE_PORT,GPIO_PIN_RESET)   //5V



#define     AD7606_OS0_HIGH()       HAL_GPIO_WritePin(AD7606_OS0_GPIOx,AD7606_OS0_PORT,GPIO_PIN_SET)   
#define     AD7606_OS0_LOW()        HAL_GPIO_WritePin(AD7606_OS0_GPIOx,AD7606_OS0_PORT,GPIO_PIN_RESET)

#define     AD7606_OS1_HIGH()       HAL_GPIO_WritePin(AD7606_OS1_GPIOx,AD7606_OS1_PORT,GPIO_PIN_SET)
#define     AD7606_OS1_LOW()        HAL_GPIO_WritePin(AD7606_OS1_GPIOx,AD7606_OS1_PORT,GPIO_PIN_RESET)

#define     AD7606_OS2_HIGH()       HAL_GPIO_WritePin(AD7606_OS2_GPIOx,AD7606_OS2_PORT,GPIO_PIN_SET)
#define     AD7606_OS2_LOW()        HAL_GPIO_WritePin(AD7606_OS2_GPIOx,AD7606_OS2_PORT,GPIO_PIN_RESET)

#define     AD7606_CONVA_HIGH()     HAL_GPIO_WritePin(AD7606_CONVA_GPIOx,AD7606_CONVA_PORT,GPIO_PIN_SET)    
#define     AD7606_CONVA_LOW()      HAL_GPIO_WritePin(AD7606_CONVA_GPIOx,AD7606_CONVA_PORT,GPIO_PIN_RESET)

#define     AD7606_CONVB_HIGH()     HAL_GPIO_WritePin(AD7606_CONVB_GPIOx,AD7606_CONVB_PORT,GPIO_PIN_SET)    
#define     AD7606_CONVB_LOW()      HAL_GPIO_WritePin(AD7606_CONVB_GPIOx,AD7606_CONVB_PORT,GPIO_PIN_RESET)
																				
//#define     AD7606_READ_DATA()      GPIO_ReadInputData(AD7606_DATA_GPIOx)

#define     AD7606_BUSY_STATE()     HAL_GPIO_ReadPin(AD7606_BUSY_GPIOx,AD7606_BUSY_PORT)
#define     AD7606_FRST_STATE()     HAL_GPIO_ReadPin(AD7606_FRST_GPIOx,AD7606_FRST_PORT)

#define     AD7606_CS_RD_LOW()      AD7606_CS_LOW();AD7606_RD_LOW()
#define     AD7606_CS_RD_HIGH()     AD7606_CS_HIGH();AD7606_RD_HIGH()


#define     AD7606_SAMPLE_200K      0    
#define     AD7606_SAMPLE_100K      1    
#define     AD7606_SAMPLE_50K       2    
#define     AD7606_SAMPLE_25K       3    
#define     AD7606_SAMPLE_12K5      4    
#define     AD7606_SAMPLE_6K25      5    
#define     AD7606_SAMPLE_3K125     6    

#define     AD7606_VOLT_0V5         1638
#define     AD7606_VOLT_3V3         10813
#define     AD7606_VOLT_3V5         11469


void AD7606_config(void);    
void AD7606_SampleRate(uint8_t sampleRate);
void AD7606_reset(void);
void AD7606_startConv(void);
uint16_t AD7606_ReadData(void);
uint8_t AD7606_readConversionValue(uint16_t *data);   

#define     AD7606_1LSB_VOLT        0.00030518   

#endif

