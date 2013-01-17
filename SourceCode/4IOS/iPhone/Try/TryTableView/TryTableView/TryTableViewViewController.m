//
//  TryTableViewViewController.m
//  TryTableView
//
//  Created by yeetong on 12-9-20.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "TryTableViewViewController.h"
#import "TryTableViewCell.h"

@interface TryTableViewViewController ()

@end

@implementation TryTableViewViewController
{
    NSMutableArray *tableData;
    NSMutableArray *tableViewImage;
    NSMutableArray *tableBrithDay;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    tableData=[NSMutableArray arrayWithObjects:@"吧三",@"张三",@"李四",@"王五",@"陈六",@"不晓得",@"不知道",
               @"啊一",@"啊二",@"啊三",@"吧一",@"吧二", nil];
    tableViewImage=[NSMutableArray arrayWithObjects:@"Brightness.ico",@"Clock alt.ico",@"Clock.ico",@"Default.ico",@"History.ico",@"Home.ico",
                    @"Mail.ico",@"Microsoft Store.ico",@"Notifications.ico",@"Origins.ico",@"Phone alt.ico",@"Pin.ico",nil];
    tableBrithDay=[NSMutableArray arrayWithObjects:@"1987-01-01",@"1987-11-21",@"1987-12-22",@"1987-08-01",@"1987-09-09",@"1987-05-01",
                   @"1986-12-24",@"1986-10-27",@"1986-11-11",@"1985-12-12",@"1986-11-12",@"1985-07-17",nil];
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}




-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [tableData count];
}

-(CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    return 76;
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *tryTableIdentifier = @"TryTableViewItem";
    /* Setp 1:
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:tryTableIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc]
                initWithStyle:UITableViewCellStyleDefault reuseIdentifier:tryTableIdentifier];
    }
    cell.textLabel.text = [tableData objectAtIndex:indexPath.row];
    cell.imageView.image=[UIImage imageNamed:[tableViewImage objectAtIndex:indexPath.row]];
    
    return cell;
     */
    TryTableViewCell *cell=(TryTableViewCell *)[tableView dequeueReusableCellWithIdentifier:tryTableIdentifier];
    if(cell==nil)
    {
        NSArray *nib = [[NSBundle mainBundle] loadNibNamed:@"TryTableViewCell" owner:self options:nil];
        cell = [nib objectAtIndex:0];
    }
    cell.img.image=[UIImage imageNamed:[tableViewImage objectAtIndex:indexPath.row]];
    cell.lblName.text=[tableData objectAtIndex:indexPath.row];
    cell.lblBrithDay.text=[tableBrithDay objectAtIndex:indexPath.row];
    
    return cell;
}

-(void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    TryTableViewCell *cell=(TryTableViewCell *)[tableView cellForRowAtIndexPath:indexPath];
    if(cell.accessoryType == UITableViewCellAccessoryCheckmark)
        cell.accessoryType=UITableViewCellAccessoryNone;
    else
        cell.accessoryType=UITableViewCellAccessoryCheckmark;
//    UIAlertView *msg=[[UIAlertView alloc] initWithTitle:@"标题" message:[NSString stringWithString:cell.lblName.text] delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
//    [msg show];
    [tableView deselectRowAtIndexPath:indexPath animated:YES];
}

-(void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
{
    [tableData removeObjectAtIndex:indexPath.row];
    [tableViewImage removeObjectAtIndex:indexPath.row];
    [tableBrithDay removeObjectAtIndex:indexPath.row];
    [tableView reloadData];
}

@end
