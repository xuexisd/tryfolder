//
//  UserRegisterViewController.m
//  CloudContact
//
//  Created by yeetong on 12-10-11.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "UserRegisterViewController.h"
#import "ASIHTTPRequest/ASIHTTPRequest.h"
#import "ASIHTTPRequest/ASIFormDataRequest.h"
#import "Global.h"
#import "MBProgressHUD.h"

@interface UserRegisterViewController ()

@end


@implementation UserRegisterViewController
@synthesize txtUserEmail;
@synthesize txtUserPWD;
@synthesize txtUserPWDComfirm;

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
    [self setTxtUserEmail:nil];
    [self setTxtUserPWD:nil];
    [self setTxtUserPWDComfirm:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

- (IBAction)txtUserEmailDone:(id)sender {
    [self.txtUserPWD select:sender];
}

- (IBAction)txtUserPWDDone:(id)sender {
    [self.txtUserPWDComfirm select:sender];
}

- (IBAction)txtUserPWDComfirmDone:(id)sender {
}

- (IBAction)btnRegister:(id)sender {
    loadingView = [[MBProgressHUD alloc] initWithView:self.navigationController.view];
	[self.navigationController.view addSubview:loadingView];
	
	loadingView.delegate = self;
	loadingView.labelText = [Global MBProgressWithSimpleLabelGet];
	
	[loadingView showWhileExecuting:@selector(RegisterAction) onTarget:self withObject:nil animated:YES];
}

-(void)RegisterAction
{
    NSURL *url =[NSURL URLWithString:[NSString stringWithFormat:@"%@/CloudContactHost/UserInfo.svc/UserInfo/NewUserInfo?userEmail=%@&userPWD=%@", [Global WCFHttpPathGet], self.txtUserEmail.text, txtUserPWDComfirm.text]];
    
    //ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    ASIFormDataRequest *request=[ASIFormDataRequest requestWithURL:url];
    [request setRequestMethod:@"POST"];
    //[request addRequestHeader : @"Content-Type" value : @"application/json"];
    
    [request startSynchronous];
    NSError *registerError=[request error];
    
    if(!registerError)
    {
        NSString *response=[request responseString];
        if([response isEqual:@""])
            response = @"Exist Account";
        UIAlertView *showMsg=[[UIAlertView alloc] initWithTitle:nil message:response delegate:nil cancelButtonTitle:@"确定" otherButtonTitles:nil, nil];
        [showMsg show];
        [self.navigationController popViewControllerAnimated:YES];
    }
    else
    {
        UIAlertView *showLoginExceptionMsg=[[UIAlertView alloc] initWithTitle:nil message:registerError.localizedDescription delegate:nil cancelButtonTitle:@"确定" otherButtonTitles:nil, nil];
        [showLoginExceptionMsg show];
    }
}
@end
