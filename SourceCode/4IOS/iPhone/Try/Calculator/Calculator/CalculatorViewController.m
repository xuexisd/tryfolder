//
//  CalculatorViewController.m
//  Calculator
//
//  Created by yeetong on 12-9-3.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "CalculatorViewController.h"

@interface CalculatorViewController ()

@end

@implementation CalculatorViewController
@synthesize btn1;
@synthesize btn2;
@synthesize btn3;
@synthesize btn4;
@synthesize btn5;
@synthesize btn6;
@synthesize btn7;
@synthesize btn8;
@synthesize btn9;
@synthesize btn0;
@synthesize btnAdd;
@synthesize btnSubtraction;
@synthesize btnMultiplication;
@synthesize btnDivide;
@synthesize txtResult;
@synthesize beforeNum;
@synthesize afterNum;
@synthesize operationed;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    operationed=beforeNum=afterNum=@"";
}

- (void)viewDidUnload
{
    [self setTxtResult:nil];
    [self setBtn1:nil];
    [self setBtn2:nil];
    [self setBtn3:nil];
    [self setBtn4:nil];
    [self setBtn5:nil];
    [self setBtn6:nil];
    [self setBtn7:nil];
    [self setBtn8:nil];
    [self setBtn9:nil];
    [self setBtn0:nil];
    [self setBtnAdd:nil];
    [self setBtnSubtraction:nil];
    [self setBtnMultiplication:nil];
    [self setBtnDivide:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}


- (IBAction)btnC:(id)sender {
//    UIAlertView *msgBox=[[UIAlertView alloc] initWithTitle:@"tite" message:@"123" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
//    [msgBox show];
    
    beforeNum = afterNum = txtResult.text = @"";
}

- (IBAction)btnCal:(id)sender
{
    if(sender == btn0)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"0"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"0"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"0"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"0"];
        }
    }
    
    if(sender == btn1)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"1"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"1"];
            //beforeNum=[beforeNum stringByAppendingString:@"1"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"1"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"1"];
            //beforeNum=[afterNum stringByAppendingString:@"1"];
        }
    }
    
    if(sender == btn2)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"2"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"2"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"2"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"2"];
        }
    }
    
    if(sender == btn3)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"3"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"3"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"3"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"3"];
        }
    }
    
    if(sender == btn4)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"4"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"4"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"4"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"4"];
        }
    }
    
    if(sender == btn5)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"5"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"5"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"5"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"5"];
        }
    }
    
    if(sender == btn6)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"6"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"6"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"6"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"6"];
        }
    }
    
    if(sender == btn7)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"7"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"7"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"7"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"7"];
        }
    }
    
    if(sender == btn8)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"8"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"8"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"8"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"8"];
        }
    }
    
    if(sender == btn9)
    {
        if(operationed == @"")
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"9"];
            beforeNum=[NSString stringWithFormat:@"%@%@",beforeNum,@"9"];
        }
        else
        {
            txtResult.text=[NSString stringWithFormat:@"%@%@",txtResult.text,@"9"];
            afterNum=[NSString stringWithFormat:@"%@%@",afterNum,@"9"];
        }
    }
    [self setLastRow];
}

-(IBAction)btnOperation:(id)sender
{
    if(sender == btnAdd)
        operationed=@"+";
    if(sender==btnSubtraction)
        operationed=@"-";
    if(sender == btnMultiplication)
        operationed=@"*";
    if(sender == btnDivide)
        operationed=@"÷";
    txtResult.text=[NSString stringWithFormat:@"%@\r\n%@\t\t\t\t\t\t",txtResult.text,operationed];
    [self setLastRow];
}

- (IBAction)btnResult:(id)sender {
    float result = 0;
    float bNum=0;
    bNum=[beforeNum floatValue];
    float aNum=0;
    aNum=[afterNum floatValue];
    if(operationed == @"+")
        result=bNum+aNum;
    if(operationed == @"-")
        result=bNum-aNum;
    if(operationed == @"*")
        result=bNum*aNum;
    if(operationed == @"÷")
        result=bNum/aNum;
    txtResult.text=[NSString stringWithFormat:@"%@\r\n=\t\t\t\t\t\t%f\r\n",txtResult.text, result];
    operationed=beforeNum=afterNum=@"";
    [self setLastRow];
}
-(void)setLastRow
{
    [txtResult scrollRectToVisible:CGRectMake(0, txtResult.contentSize.height-15, txtResult.contentSize.width, 10) animated:YES];
}
@end
