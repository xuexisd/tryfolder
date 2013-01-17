//
//  AddGroupViewController.m
//  CloudContact
//
//  Created by yeetong on 12-11-2.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "AddGroupViewController.h"
#import <AddressBook/AddressBook.h>

@interface AddGroupViewController ()

@end

@implementation AddGroupViewController
@synthesize txtGroupName;

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
}

- (void)viewDidUnload
{
    [self setTxtGroupName:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

- (IBAction)btnAddGroup:(id)sender {
    if ([txtGroupName.text isEqualToString:@""]) {
        return;
    }
    
    if([txtGroupName.text isEqualToString:@"所有联系人"])
    {
        UIAlertView *showMsgduplicate=[[UIAlertView alloc] initWithTitle:nil message:@"不能添加群组名为[所有联系人]的群组!" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
        [showMsgduplicate show];
        return;
    }
    else
    {
        bool bolAdd = true;
        ABAddressBookRef abRef=ABAddressBookCreate();
        CFErrorRef error;
        ABRecordRef group=ABGroupCreate();
        ABRecordSetValue(group, kABGroupNameProperty, (__bridge CFTypeRef)(txtGroupName.text), &error);
        ABAddressBookAddRecord(abRef, group, &error);
        bolAdd = ABAddressBookSave(abRef, &error);
        
        if(bolAdd)
        {
            UIAlertView *showMsgSuccess=[[UIAlertView alloc] initWithTitle:nil message:@"添加成功!" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
            [showMsgSuccess show];
            [self.navigationController popViewControllerAnimated:YES];
        }
        else
        {
            UIAlertView *showMsgFailed=[[UIAlertView alloc] initWithTitle:nil message:@"添加失败!" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
            [showMsgFailed show];
        }
    }
}
@end
