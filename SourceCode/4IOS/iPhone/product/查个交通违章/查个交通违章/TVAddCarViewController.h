//
//  TVAddCarViewController.h
//  查个交通违章
//
//  Created by yeetong on 13-1-9.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface TVAddCarViewController : UIViewController
@property (strong, nonatomic) IBOutlet UITextField *txtCarNumber;
- (IBAction)btnAddCar:(id)sender;
- (IBAction) textFieldDoneEditing: (id)sender; // 通过Done关闭键盘
- (IBAction) backgroundTapCloseKey: (id)sender;//通过点击空白处关闭键盘
@property (strong, nonatomic) IBOutlet UITextField *txtCarFrame;
@end
