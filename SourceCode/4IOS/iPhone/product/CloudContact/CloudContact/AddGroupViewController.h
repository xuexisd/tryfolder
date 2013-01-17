//
//  AddGroupViewController.h
//  CloudContact
//
//  Created by yeetong on 12-11-2.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface AddGroupViewController : UIViewController
@property (strong, nonatomic) IBOutlet UITextField *txtGroupName;
- (IBAction)btnAddGroup:(id)sender;

@end
