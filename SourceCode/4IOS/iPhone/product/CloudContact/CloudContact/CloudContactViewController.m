//
//  CloudContactViewController.m
//  CloudContact
//
//  Created by yeetong on 12-10-11.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "CloudContactViewController.h"
#import "ASIHTTPRequest/ASIHTTPRequest.h"
#import "Global.h"
#import "MBProgressHUD.h"

@interface CloudContactViewController ()

@end

@implementation CloudContactViewController
@synthesize txtUserEmail;
@synthesize txtUserPWD;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
}

- (void)viewDidUnload
{
    [self setTxtUserEmail:nil];
    [self setTxtUserPWD:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

- (IBAction)btnLogin:(id)sender {
    if([self.txtUserEmail.text isEqual:@""]
       ||[self.txtUserPWD.text isEqual:@""])
        return;
    [self HideCurrentKeyBoard];
    
    loadingView = [[MBProgressHUD alloc] initWithView:self.navigationController.view];
	[self.navigationController.view addSubview:loadingView];
	
	loadingView.delegate = self;
	loadingView.labelText = [Global MBProgressWithSimpleLabelGet];
	
	[loadingView showWhileExecuting:@selector(LoginTestAction) onTarget:self withObject:nil animated:YES];
}

-(void)LoginAction
{
    NSURL *url =[NSURL URLWithString:[NSString stringWithFormat:@"%@/CloudContactHost/UserInfo.svc/UserInfo/GetUserInfoDetail?userEmail=%@&userPWD=%@", [Global WCFHttpPathGet], self.txtUserEmail.text, txtUserPWD.text]];
    ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    [request startSynchronous];
    
    NSError *loginError=[request error];
    
    if (!loginError) {
        NSString *GetMsg=[request responseString];
        if([GetMsg isEqual:@""])
        {
            UIAlertView *showLoginFailedMsg=[[UIAlertView alloc] initWithTitle:nil message:@"[用户名]或[密码]错误" delegate:nil cancelButtonTitle:@"重新输入" otherButtonTitles:nil, nil];
            [showLoginFailedMsg show];
        }
        else
        {
            [self performSegueWithIdentifier:@"GoToMainContact" sender:self];
        }
    }
    else
    {
        UIAlertView *showLoginExceptionMsg=[[UIAlertView alloc] initWithTitle:nil message:loginError.localizedDescription delegate:nil cancelButtonTitle:@"确定" otherButtonTitles:nil, nil];
        [showLoginExceptionMsg show];
    }
}
-(void)LoginTestAction
{
//    sleep(2);
    [self performSegueWithIdentifier:@"GoToMainContact" sender:self];
}

- (IBAction)txtUserEmailDoneExit:(id)sender {
    [self HideCurrentKeyBoard];
    [self.txtUserPWD select:sender];
}

- (IBAction)txtUserPWDDoneExit:(id)sender {
    [self HideCurrentKeyBoard];
    [self btnLogin:sender];
}

- (IBAction)btnGoToRegister:(id)sender {
    [self HideCurrentKeyBoard];
}

-(void) HideCurrentKeyBoard
{
    [self.txtUserEmail resignFirstResponder];
    [self.txtUserPWD resignFirstResponder];
}

@end
