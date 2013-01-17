//
//  CalculatorViewController.h
//  Calculator
//
//  Created by yeetong on 12-9-3.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef NSString *calNum;

@interface CalculatorViewController : UIViewController

@property NSString *beforeNum;
@property NSString *afterNum;
@property NSString *operationed;

@property (strong, nonatomic) IBOutlet UITextView *txtResult;

- (IBAction)btnC:(id)sender;
- (IBAction)btnCal:(id)sender;
- (IBAction)btnResult:(id)sender;
- (IBAction)btnOperation:(id)sender;

@property (strong, nonatomic) IBOutlet UIButton *btn1;
@property (strong, nonatomic) IBOutlet UIButton *btn2;
@property (strong, nonatomic) IBOutlet UIButton *btn3;
@property (strong, nonatomic) IBOutlet UIButton *btn4;
@property (strong, nonatomic) IBOutlet UIButton *btn5;
@property (strong, nonatomic) IBOutlet UIButton *btn6;
@property (strong, nonatomic) IBOutlet UIButton *btn7;
@property (strong, nonatomic) IBOutlet UIButton *btn8;
@property (strong, nonatomic) IBOutlet UIButton *btn9;
@property (strong, nonatomic) IBOutlet UIButton *btn0;
@property (strong, nonatomic) IBOutlet UIButton *btnAdd;
@property (strong, nonatomic) IBOutlet UIButton *btnSubtraction;
@property (strong, nonatomic) IBOutlet UIButton *btnMultiplication;
@property (strong, nonatomic) IBOutlet UIButton *btnDivide;

@end
