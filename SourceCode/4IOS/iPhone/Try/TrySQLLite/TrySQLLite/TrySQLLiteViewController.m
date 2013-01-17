//
//  TrySQLLiteViewController.m
//  TrySQLLite
//
//  Created by yeetong on 12-10-6.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "TrySQLLiteViewController.h"
#import "FMDB/FMDatabase.h"

@interface TrySQLLiteViewController ()

@end

@implementation TrySQLLiteViewController
{
    NSMutableArray *trySqlResult;
    FMDatabase *TryDB;
}

@synthesize tv1;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    
    [self CheckDBAndLoadDefaulData];
    [self LoadDefaultData];
}

- (void)viewDidUnload
{
    [self setTv1:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

-(void)LoadDefaultData
{
    trySqlResult=[[NSMutableArray alloc] init];
    if([TryDB open])
    {
        if(![self TableIsExist:@"Table1"])
        {
            [TryDB executeUpdate:@"CREATE TABLE Table1 (ID INTEGER PRIMARY KEY, NAME text)"];
        }
        
        [TryDB executeUpdate:@"delete from Table1"];
        
        srand((unsigned int) time(NULL));
        for(int i=0;i<20;i++){
        NSString *currentInt = [NSString stringWithFormat:@"%d", rand()%100000+1];
        [TryDB executeUpdate:@"insert into Table1 (NAME) values (?)",currentInt];
        }
        FMResultSet *fResult=[TryDB executeQuery:@"select * from Table1"];
        while ([fResult next]) {
            [trySqlResult addObject:[fResult stringForColumn:@"NAME"]];
        }
        [fResult close];
    }
    [TryDB close];
}

-(void)CheckDBAndLoadDefaulData
{
    NSArray *pathList=NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *firstDocument=[pathList objectAtIndex:0];
    NSString *path=[firstDocument stringByAppendingPathComponent:@"TrySQLLite.db"];
//    NSFileManager *fileM=[NSFileManager defaultManager];
//    
//    BOOL isExist=[fileM fileExistsAtPath:path];
//    
//    if(!isExist)
//    {
//        
//    }
    TryDB=[FMDatabase databaseWithPath:path];
}

- (BOOL)TableIsExist:(NSString *)tableName
{
    BOOL retBool = NO;
    FMResultSet *rs = [TryDB executeQuery:@"select count(*) as 'count' from sqlite_master where type ='table' and name = ?", tableName];
    while ([rs next])
    {
        NSInteger count = [rs intForColumn:@"count"];
        
        if (0 == count)
        {
            retBool = NO;
        }
        else
        {
            retBool = YES;
        }
    }
    return retBool;
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [trySqlResult count];
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellName=@"TryCell";
    UITableViewCell *cell=[tableView dequeueReusableCellWithIdentifier:CellName];
    if(cell == nil)
    {
        cell=[[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellName];
    }
    cell.textLabel.text=[trySqlResult objectAtIndex:indexPath.row];
    return cell;
}

@end
