//
//  TrafficViolationViewController.h
//  查个交通违章
//
//  Created by yeetong on 13-1-9.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface TrafficViolationViewController : UIViewController <UITableViewDataSource,UITableViewDelegate>
@property (strong, nonatomic) IBOutlet UITableView *tableView1;

@end
