//
//  GroupDetailListViewController.h
//  CloudContact
//
//  Created by yeetong on 12-11-2.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <AddressBook/AddressBook.h>

@interface GroupDetailListViewController : UIViewController <UITableViewDataSource,UITableViewDelegate>
{
	UILabel *lblShowRightAlphabet;
    NSMutableArray *arrayTitle;//标题数组
}
@property ABRecordRef groupRecord;
@property(nonatomic,retain)UILabel *lblShowRightAlphabet;
@property (strong, nonatomic) IBOutlet UITableView *tableViewAllPersonInGroup;
@end
