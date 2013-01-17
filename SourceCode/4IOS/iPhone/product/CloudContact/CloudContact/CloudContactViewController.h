//
//  CloudContactViewController.h
//  CloudContact
//
//  Created by yeetong on 12-10-11.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MBProgressHUD.h"

@interface CloudContactViewController : UIViewController <MBProgressHUDDelegate>{
    MBProgressHUD *loadingView;
}
@property (strong, nonatomic) IBOutlet UITextField *txtUserEmail;
@property (strong, nonatomic) IBOutlet UITextField *txtUserPWD;
- (IBAction)txtUserEmailDoneExit:(id)sender;
- (IBAction)txtUserPWDDoneExit:(id)sender;
- (IBAction)btnGoToRegister:(id)sender;
- (IBAction)btnLogin:(id)sender;

@end
