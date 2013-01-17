//
//  TryTableViewCell.h
//  TryTableView
//
//  Created by yeetong on 12-9-20.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TryTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIImageView *img;
@property (weak, nonatomic) IBOutlet UILabel *lblName;
@property (weak, nonatomic) IBOutlet UILabel *lblBrithDay;

@end
