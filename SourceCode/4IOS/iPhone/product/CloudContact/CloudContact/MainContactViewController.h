//
//  MainContactViewController.h
//  CloudContact
//
//  Created by yeetong on 12-10-12.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>
//#import <AddressBookUI/AddressBookUI.h>

@interface MainContactViewController : UIViewController

//<UITableViewDataSource,UITableViewDelegate,ABPeoplePickerNavigationControllerDelegate,UINavigationControllerDelegate>
<UITableViewDataSource,UITableViewDelegate>
{
}
@property (strong, nonatomic) IBOutlet UITableView *tableViewGroupList;

@end
