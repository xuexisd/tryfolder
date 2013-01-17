//
//  UserRegisterViewController.h
//  CloudContact
//
//  Created by yeetong on 12-10-11.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MBProgressHUD.h"

@interface UserRegisterViewController : UIViewController <MBProgressHUDDelegate>{
    MBProgressHUD *loadingView;
}
@property (strong, nonatomic) IBOutlet UITextField *txtUserEmail;
@property (strong, nonatomic) IBOutlet UITextField *txtUserPWD;
@property (strong, nonatomic) IBOutlet UITextField *txtUserPWDComfirm;
- (IBAction)txtUserEmailDone:(id)sender;
- (IBAction)btnRegister:(id)sender;
- (IBAction)txtUserPWDDone:(id)sender;
- (IBAction)txtUserPWDComfirmDone:(id)sender;

@end
