//
//  HelloViewController.m
//  Hello
//
//  Created by yeetong on 12-8-29.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "HelloViewController.h"


//@interface HelloViewController ()
//
//@end

@implementation HelloViewController
@synthesize txt1;
@synthesize lbl1;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
}

- (void)viewDidUnload
{
    [self setTxt1:nil];
    [self setLbl1:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

-(IBAction)showMessage
{
//    UIAlertView *msgBox = [[UIAlertView alloc] initWithTitle:@"Test" message:@"show message here" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
    
//    [msgBox show];
    
    NSDate * dateNow = [NSDate date];
    NSString *msg=txt1.text;
    NSString *outMsg=[NSString stringWithFormat:@"欢迎 : %@, \n现在时间: %@", msg, dateNow];
    lbl1.text=outMsg;
    [self.txt1 resignFirstResponder];
}

- (IBAction) textFieldDoneEditing: (id)sender {
    [sender resignFirstResponder];
}

- (IBAction) backgroundTapCloseKey: (id)sender {
    [self.txt1 resignFirstResponder];
}

@end
