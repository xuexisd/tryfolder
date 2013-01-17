//
//  TVViolationInfoCell.m
//  查个交通违章
//
//  Created by yeetong on 13-1-10.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import "TVViolationInfoCell.h"

@implementation TVViolationInfoCell
@synthesize txtAddress;
@synthesize lblAmount;
@synthesize lblScore;
@synthesize lblDateTime;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        // Initialization code
    }
    return self;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
