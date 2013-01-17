//
//  MainContactViewController.m
//  CloudContact
//
//  Created by yeetong on 12-10-12.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "MainContactViewController.h"
#import <AddressBook/AddressBook.h>
//#import <AddressBookUI/AddressBookUI.h>
#import "GroupDetailListViewController.h"

@interface MainContactViewController ()

@end

@implementation MainContactViewController
{
    CFMutableArrayRef groupArray;
    ABAddressBookRef ababr;
    CFErrorRef error;
}
@synthesize tableViewGroupList;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
    
    //init title bar for add title button.
    //Buttonn for refresh all data.
    UIBarButtonItem *btnRefresh=[[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemRefresh target:self action:@selector(RefreshContact:)];
    self.navigationItem.leftBarButtonItem = btnRefresh;
    
    //Button for return Group List
    UIBarButtonItem *btnGroupList=[[UIBarButtonItem alloc] initWithTitle:@"群组" style:UIBarButtonItemStyleBordered target:nil action:nil];
    self.navigationItem.backBarButtonItem = btnGroupList;
    
    //Button for add group
    UIBarButtonItem *addGroup=[[UIBarButtonItem alloc] initWithTitle:@"添加群组" style:UIBarButtonItemStyleBordered target:self action:@selector(GoToAddGroup)];
    self.navigationItem.rightBarButtonItem=addGroup;
    
    [self LoadGroupData];
}

- (void)viewDidUnload
{
    [self setTableViewGroupList:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

-(void)viewWillAppear:(BOOL)animated
{
    if(CFArrayGetCount(groupArray) != (ABAddressBookGetGroupCount(ababr)+1))
    {
        [self LoadGroupData];
        [tableViewGroupList reloadData];
    }
    
}

-(void)LoadGroupData
{
    ababr=ABAddressBookCreate();
    
    //初始化"所有联系人"的组
    ABRecordRef allContact=ABGroupCreate();
    ABRecordSetValue(allContact, kABGroupNameProperty, @"所有联系人", &error);
    
    groupArray =(CFMutableArrayRef)ABAddressBookCopyArrayOfAllGroups(ababr);
    CFArrayInsertValueAtIndex(groupArray, 0, allContact);
}

- (IBAction)RefreshContact:(id)sender {
    [self LoadGroupData];
    [tableViewGroupList reloadData];
    
    UIAlertView *showMsg=[[UIAlertView alloc] initWithTitle:nil message:@"更新成功!" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
    [showMsg show];
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    //    return ABAddressBookGetGroupCount(ababr);
    return CFArrayGetCount(groupArray);
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    
    static NSString *tryTableIdentifier = @"GroupCell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:tryTableIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc]
                initWithStyle:UITableViewCellStyleDefault reuseIdentifier:tryTableIdentifier];
    }
    
    ABRecordRef groupRecord = (ABRecordRef) CFArrayGetValueAtIndex(groupArray, indexPath.row);
    NSString *groupValue=(__bridge NSString *)ABRecordCopyCompositeName(groupRecord);
    cell.textLabel.text = groupValue;
    
    
    return cell;
}

-(void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    //    ABPeoplePickerNavigationController *peoplePickerControler=[[ABPeoplePickerNavigationController alloc] init];
    //    peoplePickerControler.peoplePickerDelegate = self;
    //    [self presentModalViewController:peoplePickerControler animated:YES];
    //[self performSegueWithIdentifier:@"GoToCurrentGroupAllContact" sender:self];
    [tableView deselectRowAtIndexPath:indexPath animated:YES];
}

-(void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
{
    ABRecordRef delGroupRecord = (ABRecordRef) CFArrayGetValueAtIndex(groupArray, indexPath.row);
    if(![((__bridge NSString *)ABRecordCopyCompositeName(delGroupRecord)) isEqualToString:@"所有联系人"])
    {
        ABAddressBookRemoveRecord(ababr, delGroupRecord, &error);
        ABAddressBookSave(ababr, &error);
        [self LoadGroupData];
        [tableViewGroupList reloadData];
    }
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if([segue.identifier isEqualToString:@"GoToCurrentGroupAllContact"])
    {
        GroupDetailListViewController *currentGroupAllContact=segue.destinationViewController;
        NSIndexPath *indexPath = [self.tableViewGroupList indexPathForSelectedRow];
        currentGroupAllContact.groupRecord = CFArrayGetValueAtIndex(groupArray, indexPath.row);
    }
}

-(void)GoToAddGroup
{
    [self performSegueWithIdentifier:@"GoToAddGroup" sender:nil];
}

//-(void)peoplePickerNavigationControllerDidCancel:(ABPeoplePickerNavigationController *)peoplePicker
//{
//    [self dismissModalViewControllerAnimated:YES];
//}
//
//-(BOOL)peoplePickerNavigationController:(ABPeoplePickerNavigationController *)peoplePicker shouldContinueAfterSelectingPerson:(ABRecordRef)person property:(ABPropertyID)property identifier:(ABMultiValueIdentifier)identifier
//{
//    [self dismissModalViewControllerAnimated:YES];
//    return YES;
//}
//
//-(BOOL)peoplePickerNavigationController:(ABPeoplePickerNavigationController *)peoplePicker shouldContinueAfterSelectingPerson:(ABRecordRef)person
//{
//    return YES;
//}


@end
