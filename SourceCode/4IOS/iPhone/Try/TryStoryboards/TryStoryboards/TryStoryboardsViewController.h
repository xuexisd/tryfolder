//
//  TryStoryboardsViewController.h
//  TryStoryboards
//
//  Created by yeetong on 12-9-28.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface TryStoryboardsViewController : UIViewController
<UITableViewDataSource,UITableViewDelegate>
@property (strong, nonatomic) IBOutlet UITableView *tableView1;


@end
