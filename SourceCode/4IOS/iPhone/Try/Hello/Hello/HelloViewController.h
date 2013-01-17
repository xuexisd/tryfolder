//
//  HelloViewController.h
//  Hello
//
//  Created by yeetong on 12-8-29.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface HelloViewController : UIViewController

-(IBAction)showMessage;
@property (strong, nonatomic) IBOutlet UITextField *txt1;
@property (strong, nonatomic) IBOutlet UILabel *lbl1;

- (IBAction) textFieldDoneEditing: (id)sender; // 通过Done关闭键盘
- (IBAction) backgroundTapCloseKey: (id)sender;//通过点击空白处关闭键盘

@end
