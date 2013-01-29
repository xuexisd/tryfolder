//
//  TVCompletedViewController.m
//  查个交通违章
//
//  Created by yeetong on 13-1-10.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import "TVCompletedViewController.h"
#import "ASIHTTPRequest/ASIFormDataRequest.h"
#import "ASIHTTPRequest/ASIHTTPRequest.h"
#import "Global.h"
#import "TVViolationInfoCell.h"
#import "MBProgressHUD.h"

@interface TVCompletedViewController ()

@end

@implementation TVCompletedViewController
{
    NSString *responseString;
    NSMutableArray *ViolationAddressArray;
    NSMutableArray *ViolationAmountArray;
    NSMutableArray *ViolationDateTimeArray;
    NSMutableArray *ViolationScoreArray;
}
@synthesize tableView1;

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
    
    @try
    {
        ViolationAddressArray=[[NSMutableArray alloc]init];
        ViolationAmountArray=[[NSMutableArray alloc]init];
        ViolationDateTimeArray=[[NSMutableArray alloc]init];
        ViolationScoreArray=[[NSMutableArray alloc]init];
        
        loadingView = [[MBProgressHUD alloc] initWithView:self.navigationController.view];
        [self.navigationController.view addSubview:loadingView];
        loadingView.dimBackground=YES;
        loadingView.delegate = self;
        loadingView.labelText = [Global MBProgressLoadingText];
        [loadingView showAnimated:YES whileExecutingBlock:^{
            [self BaseMBLoadData];
        } completionBlock:^{
            self.tabBarItem.badgeValue=[NSString stringWithFormat:@"%d",[ViolationAddressArray count]];
            [tableView1 reloadData];
            [loadingView removeFromSuperview];
            loadingView = nil;
        }];
    }
    @catch (NSException *ex) {
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Error" message:[NSString stringWithFormat:@"%@",ex]
                                                       delegate:self cancelButtonTitle:@"OK" otherButtonTitles: nil];
        [alert show];
    }
}

- (void)viewDidUnload
{
    [self setTableView1:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

-(void)BaseMBLoadData
{
    [self PostDataforCompleted];
    [self SerializationDataFromPost];
}

-(void)PostDataforCompleted
{
    responseString = [[NSString alloc]init];
    NSError *error=nil;
    NSDictionary *scParams=[NSDictionary dictionaryWithObjectsAndKeys:[Global GetChooseCarNumber],@"CarNumber",[Global GetChooseCarFrame],@"CarFrame", nil];
    NSData *data = [NSJSONSerialization dataWithJSONObject:scParams options:kNilOptions error:&error];
    
    NSURL *url = [NSURL URLWithString:[Global GetUrlAddressCompleted]];
    ASIFormDataRequest *request=[ASIFormDataRequest requestWithURL:url];
    [request setRequestMethod:@"POST"];
    [request addRequestHeader : @"Content-Type" value : @"application/json"];
    [request appendPostData:data];
    [request setDelegate:self];
    [request startSynchronous];
    responseString = [[NSString alloc]initWithString:[request responseString]];
    
    //    responseString = @"[{\"ViolationAddress\":\"317国道郫县段15km+800m\",\"ViolationAmount\":\"100\",\"ViolationDateTime\":\"2012年07月11日14时09分\",\"ViolationScore\":\"3\"},{\"ViolationAddress\":\"武阳大道二段与太平园东二街交叉路口\",\"ViolationAmount\":\"100\",\"ViolationDateTime\":\"2012年06月22日10时55分\",\"ViolationScore\":\"3\"},{\"ViolationAddress\":\"街心花园\",\"ViolationAmount\":\"100\",\"ViolationDateTime\":\"2012年04月14日15时56分\",\"ViolationScore\":\"3\"}]";
}

-(void)SerializationDataFromPost
{
    NSError *error=nil;
    NSDictionary *jsonDict=[NSJSONSerialization JSONObjectWithData:[responseString dataUsingEncoding:NSUTF8StringEncoding allowLossyConversion:YES] options:0 error:&error];
    for(NSDictionary *currentJsonData in jsonDict)
    {
        [ViolationAddressArray addObject:[currentJsonData objectForKey:@"ViolationAddress"]];
        [ViolationAmountArray addObject:[currentJsonData objectForKey:@"ViolationAmount"]];
        [ViolationDateTimeArray addObject:[currentJsonData objectForKey:@"ViolationDateTime"]];
        [ViolationScoreArray addObject:[currentJsonData objectForKey:@"ViolationScore"]];
    }
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [ViolationAddressArray count];
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *cellname=@"CompletedInfoCell";
    TVViolationInfoCell *currentCell=[tableView dequeueReusableCellWithIdentifier:cellname];
    if(currentCell == nil)
    {
        NSArray *nib = [[NSBundle mainBundle] loadNibNamed:cellname owner:self options:nil];
        currentCell = [nib objectAtIndex:0];
    }
    currentCell.txtAddress.text=[ViolationAddressArray objectAtIndex:indexPath.row];
    currentCell.lblAmount.text = [NSString stringWithFormat:@"%@", [ViolationAmountArray objectAtIndex:indexPath.row]];
    currentCell.lblScore.text = [NSString stringWithFormat:@"%@", [ViolationScoreArray objectAtIndex:indexPath.row]];
    currentCell.lblDateTime.text = [NSString stringWithFormat:@"%@", [ViolationDateTimeArray objectAtIndex:indexPath.row]];
    return currentCell;
}

@end
