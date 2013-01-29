//
//  TrafficViolationViewController.m
//  查个交通违章
//
//  Created by yeetong on 13-1-9.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import "TrafficViolationViewController.h"
#import "Global.h"
#import "TVCompletedViewController.h"

@interface TrafficViolationViewController ()

@end

@implementation TrafficViolationViewController
{
    NSMutableArray *tableData;
    int currentTotalCars;
}
@synthesize tableView1;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    
    //Button for add Car
    UIBarButtonItem *addCar=[[UIBarButtonItem alloc] initWithTitle:@"添加车辆" style:UIBarButtonItemStyleBordered target:self action:@selector(GoToAddCar)];
    self.navigationItem.rightBarButtonItem=addCar;
    
    [self BindDataForCars];
}

- (void)viewDidUnload
{
    [self setTableView1:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

-(void)BindDataForCars
{
    NSArray *pathList=NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *firstDocument=[pathList objectAtIndex:0];
    NSString *path=[firstDocument stringByAppendingPathComponent:@"CarList.plist"];
    NSFileManager *fileM=[NSFileManager defaultManager];
    if([fileM fileExistsAtPath:path])
    {
        NSDictionary *dict=[[NSDictionary alloc]initWithContentsOfFile:path];
        tableData=[dict objectForKey:@"Cars"];
        [Global SetTotalCars:[tableData count]];
        currentTotalCars = [tableData count];
    }
    else
    {
        [fileM createFileAtPath:path contents:nil attributes:nil];
        NSDictionary* dic = [NSDictionary dictionaryWithObjectsAndKeys:[[NSArray alloc]init],@"Cars",nil];
        [dic writeToFile:path atomically:YES];
        [Global SetTotalCars:0];
        currentTotalCars = 0;
    }
}

-(void)GoToAddCar
{
    [self performSegueWithIdentifier:@"GoToAddCar" sender:nil];
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [tableData count];
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *tablename=@"CarCell";
    UITableViewCell *currentCell=[tableView dequeueReusableCellWithIdentifier:tablename];
    if(currentCell == nil)
    {
        currentCell=[[UITableViewCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:tablename];
    }
    currentCell.textLabel.text=[tableData objectAtIndex:indexPath.row];
    return currentCell;
}

-(void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    [self performSegueWithIdentifier: @"GoToshowViolationPage" sender: self ];
    
    [tableView deselectRowAtIndexPath:indexPath animated:YES];
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if([segue.identifier isEqualToString:@"GoToshowViolationPage"])
    {
        NSIndexPath *indexPath = [self.tableView1 indexPathForSelectedRow];
        [Global SetChooseCarNumber:[[tableData objectAtIndex:indexPath.row] substringToIndex:7]];
        [Global SetChooseCarFrame:[[tableData objectAtIndex:indexPath.row] substringFromIndex:14]];
    }
}

-(void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSArray *pathList=NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *firstDocument=[pathList objectAtIndex:0];
    NSString *path=[firstDocument stringByAppendingPathComponent:@"CarList.plist"];
    NSMutableDictionary *dict=[[NSMutableDictionary alloc]initWithContentsOfFile:path];
    tableData=[dict objectForKey:@"Cars"];
    [tableData removeObject:[tableData objectAtIndex:indexPath.row]];
    [dict setObject:tableData forKey:@"Cars"];
    [dict writeToFile:path atomically:YES];
    [self BindDataForCars];
    [tableView1 reloadData];

}

-(void)viewWillAppear:(BOOL)animated
{
    if(currentTotalCars != [Global GetTotalCars])
    {
        [self BindDataForCars];
        [tableView1 reloadData];
    }
    
}


@end
