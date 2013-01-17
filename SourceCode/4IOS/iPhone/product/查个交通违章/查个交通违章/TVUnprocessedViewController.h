//
//  TVUnprocessedViewController.h
//  查个交通违章
//
//  Created by yeetong on 13-1-10.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MBProgressHUD.h"

@interface TVUnprocessedViewController : UIViewController <MBProgressHUDDelegate,UITableViewDataSource,UITableViewDelegate>
{
    MBProgressHUD *loadingView;
}
@property (strong, nonatomic) IBOutlet UITableView *tableView1;

@end
