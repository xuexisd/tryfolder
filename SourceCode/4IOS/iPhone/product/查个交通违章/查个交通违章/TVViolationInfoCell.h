//
//  TVViolationInfoCell.h
//  查个交通违章
//
//  Created by yeetong on 13-1-10.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface TVViolationInfoCell : UITableViewCell
@property (strong, nonatomic) IBOutlet UITextView *txtAddress;
@property (strong, nonatomic) IBOutlet UILabel *lblAmount;
@property (strong, nonatomic) IBOutlet UILabel *lblScore;
@property (strong, nonatomic) IBOutlet UILabel *lblDateTime;

@end
