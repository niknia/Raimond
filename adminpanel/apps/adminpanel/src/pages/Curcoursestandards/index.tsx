import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurCoursestandards } from '@/data/curcoursestandards/curcoursestandards.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurCoursestandardsDto } from '@/data/curcoursestandards/curcoursestandards.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurCoursestandards();
    const { data: curCoursestandardsData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingCourseStandard, setEditingCourseStandard] = useState<CurCoursestandardsDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curCoursestandardsData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurCoursestandardsDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام استاندارد دوره',
            size: 200,
        },
        {
            accessorKey: 'createTime',
            header: 'تاریخ ایجاد',
            size: 150,
            cell: ({ getValue }: { getValue: () => any }) => {
                const date = getValue() as string;
                return date ? new Date(date).toLocaleDateString('fa-IR') : '-';
            },
        },
    ], []);

    // هندل‌های CRUD
    const handleEdit = (row: CurCoursestandardsDto) => {
        setEditingCourseStandard(row);
        open();
    };

    const handleDelete = async (row: CurCoursestandardsDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'استاندارد دوره با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف استاندارد دوره',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingCourseStandard(null);
        open();
    };

    const handleSave = async (values: Partial<CurCoursestandardsDto>) => {
        try {
            if (editingCourseStandard) {
                await updateMutation.mutateAsync({ id: editingCourseStandard.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'استاندارد دوره با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'استاندارد دوره جدید با موفقیت ایجاد شد',
                    color: 'green',
                });
            }
            close();
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در ذخیره‌سازی',
                color: 'red',
            });
        }
    };

    return (
        <BasePage>
            <Stack gap="lg">
                <Box>
                    <Title order={2}>مدیریت استانداردهای دوره</Title>
                    <Text c="dimmed">مدیریت استانداردهای مختلف دوره‌ها</Text>
                </Box>

                <DkdGrid
                    columns={columns}
                    data={data}
                    isLoading={isLoading}
                    rtl
                    height={600}
                    selectedRowId={selectedRowId}
                    onRowClick={(row: any) => setSelectedRowId(row.original.id.toString())}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    onAdd={handleAdd}
                    initialPageSize={15}
                />

                {/* Modal برای افزودن/ویرایش */}
                <Modal 
                    opened={opened} 
                    onClose={close} 
                    title={editingCourseStandard ? 'ویرایش استاندارد دوره' : 'افزودن استاندارد دوره جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام استاندارد دوره"
                            placeholder="نام استاندارد دوره"
                            defaultValue={editingCourseStandard?.name || ''}
                            name="name"
                            required
                        />
                        
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={close}>
                                انصراف
                            </Button>
                            <Button 
                                onClick={() => {
                                    const formData = new FormData(document.querySelector('form') as HTMLFormElement);
                                    const values = {
                                        name: (formData.get('name') as string) || '',
                                    };
                                    handleSave(values);
                                }}
                                loading={createMutation.isPending || updateMutation.isPending}
                            >
                                {editingCourseStandard ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 