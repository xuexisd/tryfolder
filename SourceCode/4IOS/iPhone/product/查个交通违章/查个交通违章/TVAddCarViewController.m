//
//  TVAddCarViewController.m
//  查个交通违章
//
//  Created by yeetong on 13-1-9.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import "TVAddCarViewController.h"
#import "Global.h"

@interface TVAddCarViewController ()

@end

@implementation TVAddCarViewController
{
    NSMutableArray *tableData;
}
@synthesize txtCarNumber;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
}

- (void)viewDidUnload
{
    [self setTxtCarNumber:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

- (IBAction)btnAddCar:(id)sender
{
    bool bolAdd=false;
    NSArray *pathList=NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *firstDocument=[pathList objectAtIndex:0];
    NSString *path=[firstDocument stringByAppendingPathComponent:@"CarList.plist"];
    NSMutableDictionary *dict=[[NSMutableDictionary alloc]initWithContentsOfFile:path];
    tableData=[dict objectForKey:@"Cars"];
    [tableData addObject:txtCarNumber.text];
    [dict setObject:tableData forKey:@"Cars"];
    bolAdd = [dict writeToFile:path atomically:YES];
    
    if(bolAdd)
    {
        [Global SetTotalCars:[tableData count]];
        UIAlertView *showMsgSuccess=[[UIAlertView alloc] initWithTitle:nil message:@"添加成功!" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
        [showMsgSuccess show];
        [self.navigationController popViewControllerAnimated:YES];
    }
    else
    {
        UIAlertView *showMsgFailed=[[UIAlertView alloc] initWithTitle:nil message:@"添加失败!" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
        [showMsgFailed show];
    }
    
    [self.txtCarNumber resignFirstResponder];
}

- (IBAction) textFieldDoneEditing: (id)sender {
    [sender resignFirstResponder];
}

- (IBAction) backgroundTapCloseKey: (id)sender {
    [self.txtCarNumber resignFirstResponder];
}
@end
